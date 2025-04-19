using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.Network;

namespace _03.PracticeLocators
{
    public class Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///B:/Front-End%20Test%20Automation/05.Selenium%20WebDriver/SimpleForm/Locators.html");
        }

        [Test]
        public void Test1()
        {
            // Basic Locators
            driver.FindElement(By.Id("lname"));
            driver.FindElement(By.Name("newsletter"));
            driver.FindElement(By.TagName("a"));
            driver.FindElement(By.ClassName("information"));

            // Text Link Locators
            driver.FindElement(By.LinkText("Softuni Official Page"));
            driver.FindElement(By.PartialLinkText("Official Page"));

            // CSS selectors
            driver.FindElement(By.CssSelector("#fname"));
            driver.FindElement(By.CssSelector("input[name='fname']"));
            driver.FindElement(By.CssSelector("input[class*='button']"));
            driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));
            driver.FindElement(By.CssSelector("form div.additional-info > p > input[type='text']"));

            // XPath Locators
            driver.FindElement(By.XPath("/html/body/form/input[1]"));
            driver.FindElement(By.XPath("//input[@value='m']"));
            driver.FindElement(By.XPath("//input[@name='lname']"));
            driver.FindElement(By.XPath("//input[@type='checkbox']"));
            driver.FindElement(By.XPath("//input[@class='button']"));
            driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}