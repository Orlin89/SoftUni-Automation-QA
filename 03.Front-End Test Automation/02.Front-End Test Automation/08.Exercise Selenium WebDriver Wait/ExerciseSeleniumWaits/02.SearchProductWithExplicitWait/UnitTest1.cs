using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _02.SearchProductWithExplicitWait
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@type='image']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement buyButton = wait.Until(e => e.FindElement(By.XPath("//span[text()='Buy Now']")));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                buyButton.Click();

                Assert.That(driver.PageSource.Contains("keyboard"), Is.True, "The product keyboard was not found in the cart page.");
                Console.WriteLine("Scenario completed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exeption: " + ex.Message);
            }
        }

        [Test]
        public void SearchProduct_Junk_ShouldTrownTimeotExeption()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@type='image']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try 
            {
                WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));
                IWebElement buyButton = wait.Until(e => e.FindElement(By.XPath("//span[text()='Buy Now']")));

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                buyButton.Click();

                Assert.Fail();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Pass("WebDriverTimeoutExeption was thrown: " + ex.Message);
            }

            catch(Exception exep) 
            {
               Assert.Fail("Unexpected exeption: " + exep.Message);
            }

            finally
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}