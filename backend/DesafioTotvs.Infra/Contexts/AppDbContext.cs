using DesafioTotvs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTotvs.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}