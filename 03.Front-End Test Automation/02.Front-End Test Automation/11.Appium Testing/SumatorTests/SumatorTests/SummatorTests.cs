
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;


namespace AppiumMobile_Summator
{
    [TestFixture]
    public class SummatorTests
    {
        private AndroidDriver driver;
        private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Starts Appium server no need for you to start it via CMD
            appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            appiumLocalService.Start();

            var androidOptions = new AppiumOptions();
            androidOptions.PlatformName = "Android";
            androidOptions.AutomationName = "UIAutomator2";
            androidOptions.DeviceName = "Pixel9";
            androidOptions.App = @"D:\com.example.androidappsummator.apk";

            driver = new AndroidDriver(appiumLocalService.ServiceUrl, androidOptions);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            driver?.Quit();
            driver?.Dispose();
            appiumLocalService.Dispose();
        }


        [Test]
        public void Test_ValidData()
        {
            var field1 = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            field1.Clear();
            field1.SendKeys("5");
            var field2 = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            field2.Clear();
            field2.SendKeys("5");
            var buttonCalc = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            buttonCalc.Click();
            var result = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum")).Text;

            Assert.That(result, Is.EqualTo("10"));

            
        }

        [Test]
        public void Test_InvalidData()
        {
            var field1 = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            field1.Clear();
            field1.SendKeys(".");
            var field2 = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            field2.Clear();
            var buttonCalc = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            buttonCalc.Click();
            var result = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum")).Text;

            Assert.That(result, Is.EqualTo("error"));
        }
    }
}