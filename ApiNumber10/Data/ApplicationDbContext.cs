using ApiNumber10.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNumber10.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
