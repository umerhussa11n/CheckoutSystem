using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class Price
    {
        public Price()
        {
            Currency = "GBP";
            Symbol = "£";
        }

        public Int64 Id { get; set; }

        public Double Amount { get; set; }

        public string Currency { get; set; }

        public string Symbol { get; set; }
    }
}
