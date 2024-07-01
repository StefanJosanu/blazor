using BlazorEcommerce.Server.Data.Entities;

namespace BlazorEcommerce.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
