using OpenQA.Selenium.DevTools.V131.DOM;
using SwagLabsAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Tests
{
    public class HiddenMenuTests : BaseTests
    {
        [SetUp]
        public void SetUpHiddenMenu()
        {
            Login("standard_user", "secret_sauce");
        }

        [Test]
        public void TestOpenMenu()
        {
            hiddenMenu.ClickMenuButton();
            Assert.That(hiddenMenu.IsMenuOpen(), Is.True);
        }

        [Test]
        public void TestLogout()
        {
            hiddenMenu.ClickMenuButton();
            hiddenMenu.ClickLogoutButton();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}
