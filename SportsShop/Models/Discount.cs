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
            _discountAmount = new Price();
        }

        public Int64 Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsValid { get; set; }

        private Price _discountAmount;
        public Price DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value;  }
        }
    }
}
