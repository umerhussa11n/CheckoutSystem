using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class Product
    {
        public Product()
        {
            _price = new Price();
        }

        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        private Price _price; 
        public Price Price
        {
            get { return _price;  }
            set { _price = value;  }
        }
    }
}
