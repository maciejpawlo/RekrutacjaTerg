using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Domain.Entieties
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Task<Product?> GetById(Guid id);
        Task Add(Product product);
        Task Update(Product product);
        Task SaveChanges();
    }
}
