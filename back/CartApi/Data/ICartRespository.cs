using CartApi.Models.Entities;

namespace CartApi.Data
{
    public interface ICartRespository
    {
        Task<Cart?> GetCartAsync(string userId);
        Task<Cart?> UpdateCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(string userId);
    }
}
