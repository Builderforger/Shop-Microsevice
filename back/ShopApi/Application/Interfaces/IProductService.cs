using ShopApi.Application.DTOs;

namespace ShopApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto?> GetByIdAsync(Guid id);
        Task<ProductResponseDto> CreateAsync(ProductCreateDto dto);
        Task<bool> UpdateAsync(Guid Id, ProductUpdateDto dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}
