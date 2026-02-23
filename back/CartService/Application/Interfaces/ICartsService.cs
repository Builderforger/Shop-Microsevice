using CartService.Application.DTOs;

namespace CartService.Application.Interfaces
{
    public interface ICartsService
    {
        Task<CartResponseDto?> GetCartAsync(string userId);
        Task<CartResponseDto?> UpdateCartAsync(string userId, List<CartItemCreateDto> items);
        Task DeleteCartAsync(string userId);
    }
}
