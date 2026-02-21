using Microsoft.EntityFrameworkCore;
using Mapster;
using CatalogService.Domain.Entities;
using CatalogService.Application.DTOs;
using CatalogService.Infrastructure.Data;
using CatalogService.Application.Interfaces;

namespace CatalogService.Infrastructure.Services;

public class ProductService(CatalogServiceDbContext context) : IProductService
{
    // Method get all products
    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        return await context.Products
            .Include(p => p.Category)
            .ProjectToType<ProductResponseDto>()
            .ToListAsync();
    }
    // Method get product by id
    public async Task<ProductResponseDto?> GetByIdAsync(Guid Id)
    {
        var p = await context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == Id);

        return p?.Adapt<ProductResponseDto>();
    }
    // Method create new product
    public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
    {
        var product = dto.Adapt<Product>();
        product.Id = Guid.NewGuid();

        context.Products.Add(product);
        await context.SaveChangesAsync();
        await context.Entry(product).Reference(p => p.Category).LoadAsync();

        return product.Adapt<ProductResponseDto>();
    }
    // Method update product by id
    public async Task<bool> UpdateAsync(Guid Id, ProductUpdateDto dto)
    {
        var product = await context.Products.FindAsync(Id);
        if (product == null) return false;

        dto.Adapt(product);

        await context.SaveChangesAsync();
        return true;
    }
    // Method delete product by id
    public async Task<bool> DeleteAsync(Guid Id)
    {
        var product = await context.Products.FindAsync(Id);
        if (product == null) return false;

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return true;
    }
}
