using SwagLabsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Tests
{
    public class CartTests : BaseTests
    {
        [SetUp]
        public void SetUpCartTests()
        {
            Login("standard_user", "secret_sauce");        
            inventoryPage.AddToCartByIndex(2);
            inventoryPage.ClickCartLink();
        }

        [Test]
        public void TestCartItemDisplayed()
        {
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);
        }

        [Test]
        public void TestClickCheckout()
        {
            cartPage.ClickCheckout();
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }
    }
}
