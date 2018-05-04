using System;
using Xunit;
using CheckoutSystem;
using CheckoutSystem.Service;
using Moq;
using System.Collections.Generic;
using CheckoutSystem.Models;
using System.Linq;

namespace CheckoutSystem.Tests
{
    public class DiscountServiceShould
    {
        //Mock<ShoppingBasket> _shoppingBasket;


        private void FillShoppingBasket()
        {
            var products = GetAllProducts();
            //_shoppingBasket = new Mock<ShoppingBasket>();
            //_shoppingBasket.Setup(x => x.Products).Returns(products);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Code = "A", Price = new Price { Amount = 100 , Currency = "GBP"}},
                new Product { Id = 2, Name = "Banana", Code = "B", Price = new Price { Amount = 150, Currency = "GBP" }},
                new Product { Id = 3, Name = "Grapes", Code = "C", Price = new Price { Amount = 300, Currency = "GBP" }}
            };
        }

        public DiscountServiceShould()
        {
            FillShoppingBasket();
        }


        [Fact]
        public void NotTryToApplyDiscountIfDiscountValueIsZero()
        {
            var discount = new Discount();
            var service = new DiscountService();
            service.ApplyDiscount(discount);
        }

        [Fact]
        public void NotApplyInActiveDiscount()
        {

        }

        [Fact]
        public void ApplyDiscountForMultibuy()
        {
            ///Arrange
            

            ///Act
            

            ///Asert
        }

        [Fact]
        public void ApplyDiscountOnMultibuy()
        {

        }
    }
}
