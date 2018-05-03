using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{

    public class CheckoutService : ICheckoutService
    {
        private ShoppingBasket _basket;
        public ShoppingBasket Basket
        {
            get
            {
                return _basket == null ? new ShoppingBasket() : _basket;
            }
            set
            {
                value = _basket;
            }
        }

        // get total price from the basket..
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        // Add Item to the basket
        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
