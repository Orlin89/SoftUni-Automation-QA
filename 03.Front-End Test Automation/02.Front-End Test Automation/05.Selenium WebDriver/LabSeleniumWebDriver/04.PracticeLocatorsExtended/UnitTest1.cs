using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _04.PracticeLocatorsExtended
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
            var lastName = driver.FindElement(By.Id("lname"));
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Vega"));

            var checkbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            Assert.That(checkbox.Selected, Is.False);

            var link = driver.FindElement(By.XPath("//a"));
            Assert.That(link.Text, Is.EqualTo("Softuni Official Page"));

            var infoFields = driver.FindElement(By.ClassName("information"));
            string bgColor = infoFields.GetCssValue("background-color");
            Assert.That(bgColor, Is.EqualTo("rgba(255, 255, 255, 1)"));

            // Text Link Locators
            link = driver.FindElement(By.LinkText("Softuni Official Page"));
            Assert.That(link.GetAttribute("href"), Is.EqualTo("http://www.softuni.bg/"));

            // link = driver.FindElement(By.PartialLinkText("Official Page"));
            // Assert.That(link.Displayed, Is.True);
            Assert.That(driver.FindElement(By.PartialLinkText("Official Page")).Displayed, Is.True);

            // CSS selectors
            Assert.That(driver.FindElement(By.CssSelector("#fname")).GetAttribute("value"), Is.EqualTo("Vincent"));

            Assert.That(driver.FindElement(By.CssSelector("[name='fname']")).GetAttribute("value"), Is.EqualTo("Vincent"));

            Assert.That(driver.FindElement(By.CssSelector(".button")).GetAttribute("value"), Is.EqualTo("Submit"));

            Assert.That(driver.FindElement(By.CssSelector("p > input[type='text']")).Displayed , Is.True);

            Assert.That(driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']")).Displayed, Is.True);

            // XPath Locators
            // using absolute XPath 
            Assert.That(driver.FindElement(By.XPath("/html/body/form/input[1]")).GetAttribute("value"), Is.EqualTo("m"));

            // using relative XPath 
            Assert.That(driver.FindElement(By.XPath("//form//input[@value='m']")).GetAttribute("value"), Is.EqualTo("m"));

            Assert.That(driver.FindElement(By.XPath("//input[@id='lname']")).GetAttribute("value"), Is.EqualTo("Vega"));

            Assert.That(driver.FindElement(By.XPath("//input[@name='newsletter']")).GetAttribute("type"), Is.EqualTo("checkbox"));

            Assert.That(driver.FindElement(By.XPath("//input[@class='button']")).GetAttribute("value"), Is.EqualTo("Submit"));

            Assert.That(driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']")).Displayed, Is.True);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}