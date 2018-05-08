using CheckoutSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutSystem.Service
{
    public class CheckoutService : ICheckoutService
    {
        private IProductDataService _productService;
        private IDiscountService _discountService;
        public CheckoutService(IProductDataService productService, IDiscountService discountService)
        {
            _productService = productService;
            _discountService = discountService;
        }

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

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0.0m;
            if (_basket != null)
            {
                foreach (var product in Basket.Products)
                {
                    totalPrice += product.Price.Amount;
                }
            }

            _discountService.ApplyDiscount();
 
            return totalPrice;
        }

        public void Scan(string code)
        {
            var prouct = _productService.GetAProduct(code);
            if (_basket == null)
            {
                _basket = new ShoppingBasket();
            }
            _basket.Products.Add(prouct);
        }


    }
}
