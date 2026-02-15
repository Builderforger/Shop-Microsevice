using CartApi.Data;
using CartApi.DTOs;
using CartApi.Models.Entities;
using Mapster;

namespace CartApi.Services
{
    public class CartService(ICartRespository repository) : ICartService
    {
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
            cart.Items = items.Adapt<List<CartItem>>();

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
