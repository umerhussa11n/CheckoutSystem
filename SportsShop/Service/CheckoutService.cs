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
        public CheckoutService(IProductDataService productService)
        {
            _productService = productService;
            //_basket = new ShoppingBasket();
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

        // get total price from the basket..
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        // Add Item to the basket
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
