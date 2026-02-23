using CartService.Domain.Entities;
using Mapster;
using Shared.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using CartService.Application.DTOs;
using CartService.Application.Interfaces;
using CartService.Infrastructure.Data;

namespace CartService.Infrastructure.Services
{
    public class CartsService(ICartRespository repository,
                           ProductGrpcService.ProductGrpcServiceClient productClient,
                           IHttpContextAccessor httpContextAccessor) : ICartsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ProductGrpcService.ProductGrpcServiceClient _productClient = productClient;

        public async Task<CartResponseDto?> GetCartAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId is required");

            var cart = await repository.GetCartAsync(userId);
            return cart?.Adapt<CartResponseDto>();
        }

        public async Task<CartResponseDto?> UpdateCartAsync(string userId, List<CartItemCreateDto> items)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId is required");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Items cannot be empty");

            var cart = await repository.GetCartAsync(userId) ?? new Cart { UserId = userId };
            
            cart.Items.Clear();
            
            // получить токен из текущего запроса (если есть)
            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                token = authHeader.Substring("Bearer ".Length).Trim();

            Metadata? metadata = null;
            if (!string.IsNullOrEmpty(token))
                metadata = new Metadata { { "Authorization", $"Bearer {token}" } };

            foreach (var item in items)
            {
                // явный и понятный fallback вместо бессмысленной заглушки
                string productName = "Product not found";
                decimal price = 0m;

                try
                {
                    var req = new ProductRequest { ProductId = item.ProductId.ToString() };

                    ProductResponse reply;
                    if (metadata != null)
                        reply = await _productClient.GetProductInfoAsync(req, metadata);
                    else
                        reply = await _productClient.GetProductInfoAsync(req);

                    if (reply != null && !string.IsNullOrEmpty(reply.Name))
                    {
                        productName = reply.Name;
                        price = (decimal)reply.Price;
                    }
                    // если reply пустой или Name пуст — оставляем fallback
                }
                catch (RpcException ex)
                {
                    // gRPC is unavailable - leaving an explicit fallback
                    throw new Exception("Unable to connect to the product catalog. Please try again later.", ex);
                }

                cart.Items.Add(new CartItem
                {
                    ProductId = item.ProductId,
                    ProductName = productName,
                    Price = price,
                    Quantity = item.Quantity
                });
            }

            var updatedCart = await repository.UpdateCartAsync(cart);
            return updatedCart?.Adapt<CartResponseDto>();
        }

        public async Task DeleteCartAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("UserId is required");

            await repository.DeleteCartAsync(userId);
        }
    }
}
