using System;
using Xunit;
using CheckoutSystem;
using CheckoutSystem.Service;

namespace CheckoutSystem.Tests
{
    public class CheckoutServiceShould
    {
        [Fact]
        public void AddItemToShoppingBasketOnScan()
        {
            // need to create mock dependency for it..
            var service = new CheckoutService(new InMemoryProductService());
            var ItemCode = "A";

            service.Scan(ItemCode);

            Assert.Single(service.Basket.Products);
        }
    }
}
