using BasketApi.DTOs;
using BasketApi.Models.Entities;

namespace BasketApi.Services
{
    public interface IBasketService
    {
        Task<CustomerBasket?> GetBasketAsync(string userId);
        Task<CustomerBasket?> UpdateBasketAsync(string userId, CustomerBasketResponseDto dto);
        Task DeleteBasketAsync(string userId);
    }
}
