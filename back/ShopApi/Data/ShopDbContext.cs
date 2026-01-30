using Microsoft.EntityFrameworkCore;
using ShopApi.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShopApi.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}