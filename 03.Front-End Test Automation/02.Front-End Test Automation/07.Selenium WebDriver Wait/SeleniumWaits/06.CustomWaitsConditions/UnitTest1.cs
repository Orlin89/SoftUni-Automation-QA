using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _06.CustomWaitsConditions
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
        public void RevealInputWithCustomFluentWait()
        {
            IWebElement revealedInput = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);

            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d => { 
                revealedInput.SendKeys("Displayed"); 
                return true;
            });

            //wait.Until(d => {
            //    revealedInput.SendKeys("Displayed");
            //    return revealedInput.GetAttribute("value") == "Displayed";
            // });

            Assert.That(revealedInput.Displayed, Is.True);
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