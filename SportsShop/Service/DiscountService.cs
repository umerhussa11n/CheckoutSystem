using CheckoutSystem.Models;
using System;
using System.Linq;

namespace CheckoutSystem.Service
{
    public class DiscountService : IDiscountService
    {
        public ShoppingBasket _basket;

        public DiscountService(ShoppingBasket shoppingBasket)
        {
           this._basket = shoppingBasket;
        }

        public Discount.Validator ApplyDiscount()
        {
            bool isDiscountApplied = false;
            bool isDiscountApplicable = false;

            try
            {
                if (this._basket == null)
                {
                    return Discount.Validator.NoBasket;
                }

                if (!this._basket.Products.Any())
                {
                    return Discount.Validator.NoProducts;
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
            }
            catch (Exception ex)
            {
                // log the exception, once log service is injected..
            }
            return isDiscountApplied ? Discount.Validator.DiscountApplied : Discount.Validator.NoDiscount;
        }

        private bool IsDiscountApplicable(Product product, Discount discount)
        {
            return (product.Quantity == discount.Quantity);
        }

        private void ApplyProductDiscount(Product product, Discount discount)
        {
            if (_basket.TotalAmount > 0)
            {
                _basket.TotalAmount =  _basket.TotalAmount - discount.Price.Amount;
                _basket.TotalDiscount += discount.Price.Amount;
            }
        }
    }
}
