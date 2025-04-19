using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System.Drawing.Text;

namespace AppiumSummatorApp
{
    public class Tests
    {
        private AndroidDriver driver;
        private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void Setup()
        {
            // Starts Appium server no need for you to start it via CMD
            appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            appiumLocalService.Start();


            var androidOptions = new AppiumOptions();
            androidOptions.PlatformName = "Android";
            androidOptions.AutomationName = "UiAutomator2";
            androidOptions.DeviceName = "AppiumDemoDevice";
            androidOptions.App = "B:\\Front-End Test Automation\\11.Appium Testing\\AppForTesting\\com.example.androidappsummator.apk";

            driver = new AndroidDriver(appiumLocalService.ServiceUrl, androidOptions);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            appiumLocalService.Dispose();
        }

        [Test]
        public void Test_ValidData()
        {
            var firtField = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            firtField.Clear();
            firtField.SendKeys("5");

            var secondField = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            secondField.Clear();
            secondField.SendKeys("5");

            var calcButton = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            calcButton.Click();

            var result = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

            Assert.That(result.Text, Is.EqualTo("10"));
        }

        [Test]
        public void Test_InalidData()
        {
            var firtField = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            firtField.Clear();
            firtField.SendKeys("");

            var secondField = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            secondField.Clear();
            secondField.SendKeys("text");

            var calcButton = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            calcButton.Click();

            var result = driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

            Assert.That(result.Text, Is.EqualTo("error"));
        }
    }
}