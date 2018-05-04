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
    public class CheckoutServiceShould
    {
        List<Product> _allMockedProducts; 
        Mock<InMemoryProductService> _mockInMemoryProductService;
        Mock<DiscountService> _discountService;
        

        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Code = "A", Price = new Price { Amount = 100 , Currency = "GBP"}},
                new Product { Id = 2, Name = "Banana", Code = "B", Price = new Price { Amount = 150, Currency = "GBP" }},
                new Product { Id = 3, Name = "Grapes", Code = "C", Price = new Price { Amount = 300, Currency = "GBP" }}
            };
        }

        public CheckoutServiceShould()
        {
            _mockInMemoryProductService = new Mock<InMemoryProductService>();
            _discountService = new Mock<DiscountService>();
            _allMockedProducts = GetAllProducts();
        }

        [Fact]
        public void AddItemToShoppingBasketOnScan()
        {
            _mockInMemoryProductService.Setup(x => x.GetAllProducts()).Returns(_allMockedProducts);
            var service = new CheckoutService(_mockInMemoryProductService.Object, _discountService.Object);
            var ItemCode = "A";
            service.Scan(ItemCode);
            Assert.Single(service.Basket.Products);
        }

        [Fact]
        public void ReturnTotalOfAllProductsWhenRequested()
        {
            _mockInMemoryProductService.Setup(x => x.GetAllProducts()).Returns(_allMockedProducts);
            var service = new CheckoutService(_mockInMemoryProductService.Object, _discountService.Object);
            var code = "A";
            var product = _allMockedProducts.FirstOrDefault(x => x.Code == code);
            service.Scan(product.Code);
            var totalPrice = service.GetTotalPrice();
            Assert.Equal(product.Price.Amount, totalPrice);
        }
    }
}
