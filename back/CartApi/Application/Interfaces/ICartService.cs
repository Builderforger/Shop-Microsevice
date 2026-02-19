using CartApi.Application.DTOs;

namespace CartApi.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartResponseDto?> GetCartAsync(string userId);
        Task<CartResponseDto?> UpdateCartAsync(string userId, List<CartItemCreateDto> items);
        Task DeleteCartAsync(string userId);
    }
}
