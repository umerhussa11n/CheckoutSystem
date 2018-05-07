using CheckoutSystem.Models;
using CheckoutSystem.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CheckoutSystem.Tests
{
    public class DiscountServiceShould
    {
        Mock<ShoppingBasket> _mockShoppingBasket;
        Mock<IDiscountService> _mockDiscountService;
        ShoppingBasket _shoppingBasket;

        private decimal totalAmount;
        private decimal totalDiscount;
        private bool isDiscountApplied;

        private void SetUpMockShoppingBasket()
        {
            _mockShoppingBasket = new Mock<ShoppingBasket>();
            _mockShoppingBasket.SetupGet(x => x.Products).Returns(GetAllProducts());

            if (!isDiscountApplied)
            {
                _mockShoppingBasket.SetupGet(x => x.TotalAmount).Returns(GetTotalAmount()); // because we dont want to call the checkout service and create a dependency there..
            }
        }

        public virtual List<Product> GetAllProducts()
        {
            var products = 
            new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Code = "A", Quantity = 3, Price = new Price { Amount = 0.50m , Currency = "GBP", Symbol = "£"}},
                new Product { Id = 2, Name = "Banana", Code = "B", Quantity = 2, Price = new Price { Amount = 0.30m, Currency = "GBP", Symbol = "£" }},
                new Product { Id = 3, Name = "Grapes", Code = "C", Price = new Price { Amount = 0.200m, Currency = "GBP", Symbol = "£" }},
                new Product { Id = 4, Name = "Pineapples", Code = "D", Price = new Price { Amount = 0.15m , Currency = "GBP", Symbol = "£" }, Quantity = 3,  }
            };

            var discount = GetAllDiscounts();
            foreach (var d in discount)
            {
                var product = products.FirstOrDefault(x => x.Code == d.Code);
                if (product != null)
                {
                    product.Discount.Add(d);
                }
            }
            return products;
        }

        public virtual List<Discount> GetAllDiscounts()
        {
            var discounts = new List<Discount>()
            {
            new Discount()
            {
                Id = 1,
                Code = "A",
                Price = new Price() { Amount = 0.20m, Currency = "GBP", Symbol = "£" },
                Description = "three Quantity of Product A Cost £1.30",
                IsActive = true,
                Quantity = 3,
                IsMultiBuy = true
            },
            new Discount()
            {
                Id = 1,
                Code = "B",
                Price = new Price() { Amount = 0.15m, Currency = "GBP", Symbol = "£" },
                Description = "2 Quantity of Product B Cost £0.45",
                IsActive = true,
                Quantity = 2,
                IsMultiBuy = true
            }
            };
            return discounts;
        }

        public virtual decimal GetTotalAmount()
        {
            decimal total = 0.0m;
            var products = GetAllProducts();
            foreach (var P in products)
            {
                if (P.Quantity != 0)
                {
                    total += P.Price.Amount * P.Quantity;
                }
            }
            this.totalAmount = total;
            return total;
        }

        public virtual decimal GetTotalDiscount()
        {
            decimal total = 0.0m;
            var discounts = GetAllDiscounts();
            foreach (var d in discounts)
            {
                if (d.IsActive)
                {
                    total += d.Price.Amount;
                }
            }
            this.totalDiscount = total;
            return total;
        }

        public DiscountServiceShould()
        {
            _shoppingBasket = new ShoppingBasket();
            _mockDiscountService = new Mock<IDiscountService>();
            SetUpMockShoppingBasket();
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
            {
                Id = 1,
                Code = "PINE",
                Discount = new List<Discount>() { discount },
                Name = "Pineapple",
                Price = new Price { Amount = 10, Currency = "GBP", Symbol = "£" },
                Quantity = 3
            };
            var shoppingBasket = new ShoppingBasket() { TotalAmount = 100, Products = new List<Product> { product } };
            var discountService = new DiscountService(shoppingBasket);
            var result = discountService.ApplyDiscount();
            var total = discountService._basket.TotalAmount;
            Assert.Equal(100, total);
        }

        [Fact]
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
            var mDiscount = this.GetTotalDiscount();
            var mTotal = this.GetTotalAmount();
            var mDiscountedTotal = mTotal - mDiscount;

            var discountService = new DiscountService(_mockShoppingBasket.Object);

            isDiscountApplied = true;
            var result = discountService.ApplyDiscount();
            
            var actualAmount = discountService._basket.TotalAmount;
            Assert.Equal(this.totalAmount - this.totalDiscount, actualAmount);
        }
    }
}
