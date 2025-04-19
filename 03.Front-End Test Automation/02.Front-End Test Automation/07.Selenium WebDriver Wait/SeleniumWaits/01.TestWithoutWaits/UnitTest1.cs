using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _01.TestWithoutWaits
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
        public void AddBoxWithoutWaitsFails()
        {
            driver.FindElement(By.Id("adder")).Click();
            IWebElement redBox = driver.FindElement(By.Id("box0"));

            Assert.That(redBox.Displayed, Is.True);
        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement revealedInput = driver.FindElement(By.Id("revealed"));
            revealedInput.SendKeys("Displayed");

            Assert.That(revealedInput.GetAttribute("value"), Is.EqualTo("Displayed"));
        }



        [TearDown]
        public void TearDown() 
        {
          driver.Quit();
          driver.Dispose();
        }
    }
}