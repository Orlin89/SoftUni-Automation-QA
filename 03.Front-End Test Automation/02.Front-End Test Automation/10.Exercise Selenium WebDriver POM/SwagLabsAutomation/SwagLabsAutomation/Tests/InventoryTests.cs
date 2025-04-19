using SwagLabsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Tests
{
    public class InventoryTests : BaseTests
    {
        [Test]
        public void TestInventoryDisplay()
        {
            Login("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(driver);

            Assert.That(inventoryPage.IsINventoryDisplayed(), Is.True);
        }

        [Test]
        public void TestAddToCartByIndex()
        {
            Login("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(driver);

            inventoryPage.AddToCartByIndex(2);
            inventoryPage.ClickCartLink();

            var cartPage = new CartPage(driver);
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);


        }

        [Test]
        public void AddToCartByName()
        {
            Login("standard_user", "secret_sauce");
            var inventoryPage = new InventoryPage(driver);

            inventoryPage.AddToCartByName("Sauce Labs Backpack");
            inventoryPage.ClickCartLink();

            var cartPage = new CartPage(driver);
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);
        }

        [Test]
        public void TestPageTitle()
        {
            Login("standard_user", "secret_sauce");
            var inventoryPage = new InventoryPage(driver);

            Assert.That(inventoryPage.IsPageLoaded, Is.True);   
        }
    }
}
