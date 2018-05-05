using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class Discount
    {
        
        public Discount()
        {
            _price = new Price();
        }

        public Int64 Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsMultiBuy { get; set; }

        private Price _price;
        public Price Price
        {
            get { return _price; }
            set { _price = value;  }
        }

        public Int64 Quantity { get; set; }

        public enum Validator
        {
            NoDiscount,
            NoBasket,
            NoProducts,
            DiscountApplied
        }
    }
}
