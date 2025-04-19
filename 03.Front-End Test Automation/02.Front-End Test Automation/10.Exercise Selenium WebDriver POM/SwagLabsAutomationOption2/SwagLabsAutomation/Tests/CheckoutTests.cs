using SwagLabsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Tests
{
    public class CheckoutTests : BaseTests
    {
        [SetUp]
        public void SetUpCheckout()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(3);
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckout(); 
        }

        [Test]
        public void TestCheckoutPageLoaded()
        { 
            Assert.That(checkoutPage.IsPageLoaded, Is.True);
        }

        [Test]
        public void TestContinueToNextStep()
        {          
            checkoutPage.EnterFirstName("SomeName");
            checkoutPage.EnterLastName("LastName");
            checkoutPage.EnterPostalCode("1000");
            checkoutPage.ClickContinue();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Test]
        public void TestCompleteOrder()
        {
            checkoutPage.EnterFirstName("SomeName");
            checkoutPage.EnterLastName("LastName");
            checkoutPage.EnterPostalCode("1000");
            checkoutPage.ClickContinue();
            checkoutPage.ClickFinish();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));
            Assert.That(checkoutPage.IsCheckoutComplete(), Is.True);
        }
    }
}
