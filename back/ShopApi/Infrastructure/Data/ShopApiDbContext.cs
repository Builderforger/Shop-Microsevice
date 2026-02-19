using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShopApi.Infrastructure.Data
{
    public class ShopApiDbContext : DbContext
    {
        public ShopApiDbContext(DbContextOptions<ShopApiDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Электроника" },
                new Category { Id = 2, Name = "Мебель" },
                new Category { Id = 3, Name = "Одежда" },
                new Category { Id = 4, Name = "Инструменты" }
            );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    } 
}