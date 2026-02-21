using Microsoft.EntityFrameworkCore;
using CatalogService.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CatalogService.Infrastructure.Data
{
    public class CatalogServiceDbContext : DbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options)
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