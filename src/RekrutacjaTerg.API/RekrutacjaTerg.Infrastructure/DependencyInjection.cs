using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RekrutacjaTerg.Domain.Entieties;
using RekrutacjaTerg.Infrastructure.Persistance;
using RekrutacjaTerg.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<RekrutacjaTergDbContext>(
                options =>
                {
                    options.UseInMemoryDatabase(databaseName: "InMemoryDb");
                });
            //NOTE: had to run it in order to get data seeded into db
            //In prod data would be seeded by migration
            var dbContext = services.BuildServiceProvider().GetRequiredService<RekrutacjaTergDbContext>();
            dbContext.Database.EnsureCreated();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
