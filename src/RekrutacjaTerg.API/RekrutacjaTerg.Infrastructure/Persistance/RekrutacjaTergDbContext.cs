using Microsoft.EntityFrameworkCore;
using RekrutacjaTerg.Domain.Entieties;

namespace RekrutacjaTerg.Infrastructure.Persistance
{
    public class RekrutacjaTergDbContext : DbContext
    {
        public RekrutacjaTergDbContext()
        {
            
        }

        public RekrutacjaTergDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Product>(p => p.HasData(
                Product.Create("123456", "Sony TV", 5399.99m),
                Product.Create("654321", "Samsung TV", 4000.00m),
                Product.Create("456789", "LG TV", 3999.95m),
                Product.Create("987654", "Panasonic TV", 3399.99m)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
