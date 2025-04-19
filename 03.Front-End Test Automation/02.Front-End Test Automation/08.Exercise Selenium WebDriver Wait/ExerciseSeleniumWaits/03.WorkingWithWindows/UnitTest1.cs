using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace _03.WorkingWithWindows
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        }

        [Test]
        public void HandleMUltipleWindows()
        {
            driver.FindElement(By.XPath("//div[@class='example']//a")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            Assert.That(windowHandles.Count, Is.EqualTo(2));
            driver.SwitchTo().Window(windowHandles[1]);

            var newWindowTitle = driver.FindElement(By.TagName("h3"));
            Assert.That(newWindowTitle.Text, Is.EqualTo("New Window"));

            driver.Close();
            driver.SwitchTo().Window(windowHandles[0]);

            var defautWindowButton = driver.FindElement(By.XPath("//div[@class='example']//a"));
            Assert.That(defautWindowButton.Text, Is.EqualTo("Click Here"));
        }

        [Test]
        public void HandleNoSuchWindowExeption() 
        {
            driver.FindElement(By.XPath("//div[@class='example']//a")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
            Assert.That(windowHandles.Count, Is.EqualTo(2));

            driver.SwitchTo().Window(windowHandles[1]);
            var newWindowTitle = driver.FindElement(By.TagName("h3"));
            Assert.That(newWindowTitle.Text, Is.EqualTo("New Window"));

            driver.Close();

            try 
            {
                driver.SwitchTo().Window(windowHandles[1]);
                Assert.Fail("Window should be closed");
            }

            catch(NoSuchWindowException ex)
            {
                Assert.Pass("Correct - window was closed: " + ex.Message);
            }

            finally
            {
                driver.SwitchTo().Window(windowHandles[0]);
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