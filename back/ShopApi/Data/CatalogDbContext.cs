using Microsoft.EntityFrameworkCore;
using ShopApi.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShopApi.Data
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}