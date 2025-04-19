using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;
using System;

namespace Swipe
{
    [TestFixture]
    public class SwipeAndroidTest
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            // Start the Appium service
            _appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            _appiumLocalService.Start();

            // Set desired capabilities
            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UIAutomator2",
                DeviceName = "Pixel9",
                App = @"D:\ApiDemos-debug.apk"
            };

            // Initialize the driver
            _driver = new AndroidDriver(_appiumLocalService.ServiceUrl, androidOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void SwipeTest()
        {
            var views = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            var gallery = _driver.FindElement(MobileBy.AccessibilityId("Gallery"));
            gallery.Click();

            var photos = _driver.FindElement(MobileBy.AccessibilityId("1. Photos"));
            photos.Click();

            var pic1 = _driver.FindElements(By.ClassName("android.widget.ImageView"))[0];

           // Perform swipe action using Actions
            var action = new Actions(_driver);
            var swipe = action.ClickAndHold(pic1)
                              .MoveByOffset(-200, 0)
                              .Release()
                              .Build();
            swipe.Perform();

            // Verify swipe action
            var pic3 = _driver.FindElements(By.ClassName("android.widget.ImageView"))[2];
            Assert.That(pic3, Is.Not.Null, "The third picture was not found after swiping.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService?.Dispose();
        }
    }
}