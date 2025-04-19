using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _03.ImplicitWaits
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
        public void AddBoxWithImplicitWait()
        {
            driver.FindElement(By.Id("adder")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            IWebElement redBox = driver.FindElement(By.Id("box0"));


            Assert.That(redBox.Displayed, Is.True);
        }

        [Test]
        public void RevealInputWithImplicitWaits()
        {
            driver.FindElement(By.Id("reveal")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement revealedInput = driver.FindElement(By.Id("revealed"));

            Assert.That(revealedInput.TagName, Is.EqualTo("input"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}