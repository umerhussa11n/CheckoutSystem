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
            var service = new CheckoutService();
            var ItemCode = "A";

            service.Scan(ItemCode);

            Assert.Single(service.Basket.Items);
        }
    }
}
