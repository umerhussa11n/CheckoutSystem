﻿using System;
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
        public virtual List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public int Quantity { get; set; }

        private decimal _totalAmount =  0.0m;
        public virtual decimal TotalAmount {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
            }
        }

        private Decimal _totalDiscount; 
        public Decimal TotalDiscount
        {
            get
            {
                return _totalDiscount;
            }
            set
            {
                _totalDiscount = value;
            }
        }
    }
}
