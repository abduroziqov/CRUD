using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DbConfiguration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public DbSet<E_Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=Linda; User Id=postgres; Password=quvonch11;");
        }
    }
}
