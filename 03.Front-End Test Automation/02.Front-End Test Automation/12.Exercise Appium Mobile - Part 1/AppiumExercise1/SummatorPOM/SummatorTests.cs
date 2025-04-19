using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace SummatorPOM
{
    public class SummatorTests
    {
        private AndroidDriver driver;
        private AppiumLocalService appiumLocalService;
        public SummatorPOM summatorPOM;

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
            androidOptions.App = "B:\\Front-End Test Automation\\12.Exercise Appium Mobile - Part 1\\Resources\\com.example.androidappsummator.apk";

            driver = new AndroidDriver(appiumLocalService.ServiceUrl, androidOptions);

            summatorPOM = new SummatorPOM(driver);
        }

        [Test]
        public void Test_ValidData()
        {           
            var result = summatorPOM.Calculator("5", "5");

            Assert.That(result, Is.EqualTo("10"));
        }

        [Test]
        public void Test_InvalidData()
        {         
            var result = summatorPOM.Calculator("", "text");

            Assert.That(result, Is.EqualTo("error"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
            appiumLocalService?.Dispose();
        }
    }
}