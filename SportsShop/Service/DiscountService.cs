using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public class DiscountService : IDiscountService
    {
        private ShoppingBasket _basket;
        public ShoppingBasket Basket
        {
            get
            {
                if (this._basket == null)
                    return new ShoppingBasket();
                else
                    return this._basket;
            }
            set
            {
                this._basket = value;
            }
        }

        public void ApplyDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}
