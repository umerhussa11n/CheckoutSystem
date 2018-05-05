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
        Mock<ShoppingBasket> _mockShoppingBasket;
        Mock<IDiscountService> _mockDiscountService;
        ShoppingBasket _shoppingBasket;

        private void PopulateMockShoppingBasket()
        {
            _mockShoppingBasket = new Mock<ShoppingBasket>();
            _mockShoppingBasket.SetupGet(x => x.Products).Returns(GetAllProducts());
        }

        public virtual List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Code = "A", Price = new Price { Amount = 2.50m , Currency = "GBP"}},
                new Product { Id = 2, Name = "Banana", Code = "B", Price = new Price { Amount = 0.20m, Currency = "GBP" }},
                new Product { Id = 3, Name = "Grapes", Code = "C", Price = new Price { Amount = 3.50m, Currency = "GBP" }},
                new Product { Id = 4, Name = "Pineapples", Code = "D", Price = new Price { Amount = 1.30m , Currency = "GBP"}, Quantity = 3 }
            };
        }

        public DiscountServiceShould()
        {
            _shoppingBasket = new ShoppingBasket();
            _mockDiscountService = new Mock<IDiscountService>();
            PopulateMockShoppingBasket();
        }

        [Fact]
        public void ReturnEmptyBasketValueIfBasketIsEmpty()
        {
            var discount = new Discount()
            {
                Id = 1,
                Code = "PINE3",
                Price = new Price() { Amount = 0, Currency = "GBP", Symbol = "£" },
                Description = "Three Pineaples Cost 130",
                IsActive = true,
                Quantity = 3,
                IsMultiBuy = true
            };

            var discountService = new DiscountService(null);
            Assert.Equal(Discount.Validator.NoBasket, discountService.ApplyDiscount());
        }

        [Fact]
        public void ReturnNoDiscountValueIfDiscountIsZero()
        {
            var discount = new Discount()
            {
                Id = 1,
                Code = "PINE3",
                Price = new Price() { Amount = 0, Currency = "GBP", Symbol = "£" },
                Description = "Three Pineaples Cost 130",
                IsActive = true,
                Quantity = 3,
                IsMultiBuy = true
            };

            var shoppingBasket = new ShoppingBasket();
            var discountService = new DiscountService(shoppingBasket);
            Assert.Equal(Discount.Validator.NoDiscount, discountService.ApplyDiscount());
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
