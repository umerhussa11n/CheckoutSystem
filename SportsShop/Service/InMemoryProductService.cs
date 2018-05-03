using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public class InMemoryProductService : IProductDataService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Code = "A" },
                new Product { Id = 2, Name = "Banana", Code = "B" },
                new Product { Id = 3, Name = "Grapes", Code = "C" }
            };
        }

        public Product GetAProduct(string code)
        {
            var product = GetAllProducts()
                                .FirstOrDefault(p => p.Code == code);

            return product;
        }
    }
}
