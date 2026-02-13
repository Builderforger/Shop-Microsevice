using BasketApi.Models.Entities;

namespace BasketApi.Data
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string userId);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string userId);
    }
}
