using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class ShoppingBasket
    {
        public ShoppingBasket()
        {
            _products = new List<Product>();
        }

        public Int64 Id { get; set; }

        private List<Product> _products; 
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public int Quantity { get; set; }

        public double TotalAmount { get; set; }
    }
}
