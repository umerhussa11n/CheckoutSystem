using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public interface IProductDataService
    {
         IEnumerable<Item> GetAllProducts();
    }
}
