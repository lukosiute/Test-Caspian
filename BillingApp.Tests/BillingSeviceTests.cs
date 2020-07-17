using BillingApp.Entities;
using BillingApp.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace BillingApp.Tests
{
    public class BillingServiceTests
    {

        private readonly IBillingService _service;
        public BillingServiceTests()
        {
            _service = new BillingService(new MenuItemRepository());
        }

        [Theory]
        [InlineData(new string[]{ "Coffee", "Cola", "Cheese Sandwich" }, 3.85)]
        [InlineData(new string[]{ "Coffee", "Coffee", "Coffee" }, 3)]
        [InlineData(new string[]{ "Coffee", "Cola", "Coffee", "Steak Sandwich", "Cheese Sandwich" }, 10.8)]
        [InlineData(new string[]{ "Coffee", "Cola", "Coffee", "Steak Sandwich" }, 8.4)]
        [InlineData(new string[]{ "Bat Soup", "Steamed Broccoli", "Boiled Steak"}, 0)]
        [InlineData(new string[] { }, 0)]
        
        public async void Calculates_price_of_purchased_items(string[] purchasedItems, double expected)
        {

            var result = await _service.CalculatePrice(purchasedItems);

            Assert.Equal(expected, result);
        }

    }
}
