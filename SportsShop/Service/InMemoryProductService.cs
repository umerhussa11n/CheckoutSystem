using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    /// <summary>
    ///  this is one way we could get the products without the TDD Approach..
    ///  this interface could have been passed before connecting to database and having methods 
    ///  returning real products.... 
    ///  this is just added for proof of concept and is not required while doing TDD now..
    /// </summary>
    public class InMemoryProductService : IProductDataService
    {
        public virtual IEnumerable<Product> GetAllProducts()
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
