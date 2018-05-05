using CheckoutSystem.Models;
using System;
using System.Linq;

namespace CheckoutSystem.Service
{
    public class DiscountService : IDiscountService
    {
        private ShoppingBasket _basket;

        public DiscountService(ShoppingBasket shoppingBasket)
        {
           this._basket = shoppingBasket;
        }

        public bool ApplyDiscount()
        {
            bool isDiscountApplied = false;
            bool isDiscountApplicable = false;

            if (this._basket == null)
            {
                throw new Exception("Error: No Basket found");
            }

            if (!this._basket.Products.Any())
            {
                throw new Exception("Error: No Discount Can be Applied as the basket is Empty");
            }


            foreach (var product in _basket.Products)
            {
                var activeDiscount = product.Discount.FirstOrDefault(x => x.IsActive == true);
                if (activeDiscount != null)
                {
                    isDiscountApplicable = IsDiscountApplicable(product, activeDiscount);
                    if (isDiscountApplicable)
                    {
                        ApplyProductDiscount(product, activeDiscount);
                        isDiscountApplied = true;
                    }
                }
            }
            return isDiscountApplied;
        }

        private bool IsDiscountApplicable(Product product, Discount discount)
        {
            return (product.Quantity == discount.Quantity);
        }

        private bool ApplyProductDiscount(Product product, Discount discount)
        {
            if (_basket.TotalAmount > 0)
            {
                _basket.TotalAmount =  _basket.TotalAmount - discount.Price.Amount;
                _basket.TotalDiscount += discount.Price.Amount;
            }

            return false;
        }
    }
}
