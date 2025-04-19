using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;


namespace Scroll
{
    [TestFixture]
    public class ScrollAndroidTest
    {
        private AndroidDriver driver;
        private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            appiumLocalService.Start();

            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UIAutomator2",
                DeviceName = "Pixel9",
                App = @"D:\ApiDemos-debug.apk"
            };


            driver = new AndroidDriver(appiumLocalService.ServiceUrl, androidOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            
        }
        private void ScrollToText(string text)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"" + text + "\"))"));
        }

        [Test]
        public void ScrollTest()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            ScrollToText("Lists");

            var lists = driver.FindElement(MobileBy.AccessibilityId("Lists"));
            Assert.That(lists, Is.Not.Null, "The 'Lists' element was not found after scrolling.");

            lists.Click();

            var elementInList = driver.FindElement(MobileBy.AccessibilityId("10. Single choice list"));
            Assert.That(elementInList, Is.Not.Null, "The expected element in the list was not found.");
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            appiumLocalService?.Dispose();
        }
    }
}