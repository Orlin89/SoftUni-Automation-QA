using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace _07.Exceptions
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

            Assert.Throws<NoSuchElementException>(() =>
            {
                IWebElement redBox = driver.FindElement(By.Id("box0"));
            });
        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.Id("reveal")).Click();

            Assert.Throws<ElementNotInteractableException>(() =>
            {
                IWebElement revealedInput = driver.FindElement(By.Id("revealed"));
                revealedInput.SendKeys("Displayed");
            });
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}