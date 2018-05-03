using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Models
{
    public class ShoppingBasket
    {
        public Int64 Id { get; set; }

        private List<Item> _items; 
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int Quantity { get; set; }

        public double TotalAmount { get; set; }
    }
}
