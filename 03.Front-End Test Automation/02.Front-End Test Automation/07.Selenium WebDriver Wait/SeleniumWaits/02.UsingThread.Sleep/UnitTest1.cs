using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02.UsingThread.Sleep
{
    public class Tests
    {
        IWebDriver driver;  

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [Test]
        public void AddBoxWithThreadSleep()
        {
            driver.FindElement(By.Id("adder")).Click();
            Thread.Sleep(3000);
            IWebElement redBox = driver.FindElement(By.Id("box0"));

            Assert.That(redBox.Displayed, Is.True);
        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}