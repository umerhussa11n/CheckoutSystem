using CheckoutSystem.Models;
using CheckoutSystem.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

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
                new Product { Id = 1, Name = "Apple", Code = "A", Price = new Price { Amount = 2.50m , Currency = "GBP", Symbol = "£"}},
                new Product { Id = 2, Name = "Banana", Code = "B", Price = new Price { Amount = 0.20m, Currency = "GBP", Symbol = "£" }},
                new Product { Id = 3, Name = "Grapes", Code = "C", Price = new Price { Amount = 3.50m, Currency = "GBP", Symbol = "£" }},
                new Product { Id = 4, Name = "Pineapples", Code = "D", Price = new Price { Amount = 1.30m , Currency = "GBP", Symbol = "£" }, Quantity = 3,  }
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
            var discount = new Discount()
            {
                Id = 1,
                Code = "PINE3",
                Price = new Price() { Amount = 0, Currency = "GBP", Symbol = "£" },
                Description = "Three Pineaples Cost 130",
                IsActive = false,
                Quantity = 3,
                IsMultiBuy = true
            };

            
            var product = new Product()
                    { Id = 1, Code = "PINE",
                      Discount = new List<Discount>() { discount },
                      Name = "Pineapple",
                      Price = new Price { Amount = 10, Currency = "GBP", Symbol = "£" },
                      Quantity = 3
                    };
            var shoppingBasket = new ShoppingBasket() { TotalAmount = 100, Products = new List<Product> { product }};
            var discountService = new DiscountService(shoppingBasket);
            var result = discountService.ApplyDiscount();
            var total = discountService._basket.TotalAmount;
            Assert.Equal(100, total);
        }

        [Fact] /// REview this test later as this is not fully implemented yet...
        public void ApplyDiscountForSingleProductMultibuy()
        {
            var discount = new Discount()
            {
                Id = 1,
                Code = "PINE3",
                Price = new Price() { Amount = 0.30m, Currency = "GBP", Symbol = "£" },
                Description = "Three Pineaples Cost £1.30",
                IsActive = true,
                Quantity = 3,
                IsMultiBuy = true
            };


            var product = new Product()
            {
                Id = 1,
                Code = "D",
                Discount = new List<Discount>() { discount },
                Name = "Pineapple",
                Price = new Price { Amount = 0.50m, Currency = "GBP", Symbol = "£" },
                Quantity = 3
            };

            var shoppingBasket = new ShoppingBasket() { TotalAmount = 1.50m, Products = new List<Product> { product } };
            var discountService = new DiscountService(shoppingBasket);
            var result = discountService.ApplyDiscount();
            var total = discountService._basket.TotalAmount;
            Assert.Equal(1.20m, total);
        }

        [Fact]
        public void ApplyDiscountForMultipleItemsMultibuy()
        {
                
        }
    }
}
