using BasketApi.Data;
using BasketApi.DTOs;
using BasketApi.Models.Entities;
using Mapster;

namespace BasketApi.Services
{
    public class BasketService(IBasketRepository repository) : IBasketService
    {
        public async Task<CustomerBasket?> GetBasketAsync(string userId)
        {
            var basket = await repository.GetBasketAsync(userId);
            return basket ?? new CustomerBasket(userId);
        }
        public async Task<CustomerBasket?> UpdateBasketAsync(string userId, CustomerBasketResponseDto dto)
        {
            var basket = dto.Adapt<CustomerBasket>();
            basket.UserId = userId;
            var updatedBasket = await repository.UpdateBasketAsync(basket);
            return updatedBasket ?? basket;
        }
        public async Task DeleteBasketAsync(string userId)
        {
            await repository.DeleteBasketAsync(userId);
        }
    }
}
