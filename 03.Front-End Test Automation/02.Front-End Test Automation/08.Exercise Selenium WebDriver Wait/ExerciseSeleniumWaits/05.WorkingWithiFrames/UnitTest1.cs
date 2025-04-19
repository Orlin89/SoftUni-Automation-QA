using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _05.WorkingWithiFrames
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
        }

        [Test]
        public void TestFrameByIndex()
        {
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.XPath("//div[@class='dropdown']//button")).Click();

            var linkElements = driver.FindElements(By.XPath("//div[@class='dropdown-content']//a"));

            foreach (var link in linkElements)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void TestFrameById() 
        {
            driver.SwitchTo().Frame("result");
            driver.FindElement(By.XPath("//div[@class='dropdown']//button")).Click();

            var linkElements = driver.FindElements(By.XPath("//div[@class='dropdown-content']//a"));

            foreach (var link in linkElements)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void TestFrameByWebElement() 
        {
            var frameElement = driver.FindElement(By.CssSelector("#result"));
            driver.SwitchTo().Frame(frameElement);

            driver.FindElement(By.XPath("//div[@class='dropdown']//button")).Click();

            var linkElements = driver.FindElements(By.XPath("//div[@class='dropdown-content']//a"));

            foreach (var link in linkElements)
            {
                Console.WriteLine(link.Text);
                Assert.That(link.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}