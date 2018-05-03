﻿using CheckoutSystem.Models;
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

        public double GetTotalPrice()
        {
            double totalPrice = 0.0d;
            if (_basket != null)
            {
                foreach (var product in Basket.Products)
                {
                    totalPrice += product.Price.Amount;
                }
            }
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
