using ShopApi.DTOs;
using ShopApi.Models.Entities;
using ShopApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopApi.Service
{
    public class ProductService(ShopApiDbContext context) : IProductService
    {
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await context.Products
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Category = p.Category,
                    Price = p.Price
                })
                .ToListAsync();
        }
        public async Task<ProductResponseDto?> GetByIdAsync(Guid Id)
        {
            var p = await context.Products.FindAsync(Id);
            if (p == null) return null;

            return new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Price = p.Price
            };
        }
        public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Price = dto.Price
            };
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            };
        }
        public async Task<bool> UpdateAsync(Guid Id, ProductUpdateDto dto)
        {
            var product = await context.Products.FindAsync(Id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Category = dto.Category;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var product = await context.Products.FindAsync(Id);
            if (product == null) return false;
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
