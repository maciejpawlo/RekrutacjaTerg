using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekrutacjaTerg.Domain.Entieties
{
    public class Product
    {
        private Product(string code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Product Create(string code, string name, decimal price)
        {
            return new Product(code, name, price);
        }
    }
}
