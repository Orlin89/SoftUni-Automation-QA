using OpenQA.Selenium;
using SwagLabsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Tests
{
    [TestFixture]
    public class LoginTests : BaseTests
    {
        [Test]
        public void TestLoginWithValidCredentials()
        {
            Login("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(driver);

            Assert.That(inventoryPage.IsPageLoaded(), Is.True);
           
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {
            Login("InvalidUser", "InvalidPassword");

            var loginPage = new LoginPage(driver);

            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [Test]
        public void TestLoginWithLockedOutUser()
        {
            Login("locked_out_user", "secret_sauce");

            var loginPage = new LoginPage(driver);

            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        }
    }
}
