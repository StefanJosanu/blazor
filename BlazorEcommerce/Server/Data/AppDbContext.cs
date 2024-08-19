namespace BlazorEcommerce.Server;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {       
    }

    public DbSet<Product> Products{ get; set; }
    public DbSet<Location> Locations{ get; set; }
}
