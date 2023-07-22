using Microsoft.EntityFrameworkCore;
using RekrutacjaTerg.Domain.Entieties;
using RekrutacjaTerg.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RekrutacjaTergDbContext context;

        public ProductRepository(RekrutacjaTergDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public IQueryable<Product> GetAll()
        {
            return context.Products.AsQueryable();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            context.Products.Update(product);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
