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
                Product.Create("987654", "Panasonic TV", 3399.99m),
                Product.Create("123456", "iPhone", 5399.99m),
                Product.Create("654321", "Samsung Galaxy S", 4000.00m),
                Product.Create("456789", "Playstation", 3999.95m),
                Product.Create("987654", "Xbox", 3399.99m),
                Product.Create("123456", "Macbook Air", 5399.99m),
                Product.Create("654321", "PC", 4000.00m),
                Product.Create("456789", "PS VR", 3999.95m),
                Product.Create("987654", "Lenovo Thinkpad", 3399.99m),
                Product.Create("123456", "Sony TV test", 5399.99m),
                Product.Create("654321", "Dell Latitude", 4000.00m),
                Product.Create("456789", "Macbook Pro", 3999.95m),
                Product.Create("987654", "Huawei", 3399.99m),
                Product.Create("123456", "Google Pixel", 5399.99m),
                Product.Create("654321", "Logitech G29", 4000.00m),
                Product.Create("456789", "Thrustmaster", 3999.95m),
                Product.Create("987654", "Nvidia", 3399.99m)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
