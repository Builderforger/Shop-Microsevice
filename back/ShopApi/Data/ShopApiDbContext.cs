using Microsoft.EntityFrameworkCore;
using ShopApi.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShopApi.Data
{
    public class ShopApiDbContext : DbContext
    {
        public ShopApiDbContext(DbContextOptions<ShopApiDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}