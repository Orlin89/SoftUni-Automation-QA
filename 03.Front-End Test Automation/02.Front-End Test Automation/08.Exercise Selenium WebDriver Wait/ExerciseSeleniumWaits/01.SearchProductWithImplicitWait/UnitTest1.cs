using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _01.SearchProductWithImplicitWait
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

            try 
            {
                driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();

                var cartTitle = driver.FindElement(By.TagName("h1"));
                Assert.That(cartTitle.Text, Is.EqualTo("What's In My Cart?"));

                var productNameInCart = driver.FindElement(By.XPath("//td//a//strong"));
                Assert.That(productNameInCart.Text, Is.EqualTo("Microsoft Internet Keyboard PS/2"));
            }
            catch (Exception ex) 
            { 
                Assert.Fail("Unexpected exeption: " + ex.Message);
            }
        }
        [Test]
        public void SearchProduct_Junk_ShouldTrownNoSuchElementExeption()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@type='image']")).Click();

            try
            {
                driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();
            }
            catch (NoSuchElementException ex) 
            {
                Assert.Pass("Expectet NoSuchElementExeption was trown.");
                Console.WriteLine("Timeout - " + ex.Message);
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