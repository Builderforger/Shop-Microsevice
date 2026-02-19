using CartApi.Domain.Entities;

namespace CartApi.Infrastructure.Data
{
    public interface ICartRespository
    {
        Task<Cart?> GetCartAsync(string userId);
        Task<Cart?> UpdateCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(string userId);
    }
}
