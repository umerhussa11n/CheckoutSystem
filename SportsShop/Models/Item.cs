using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class Product
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}
