using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.ComponentModel.DataAnnotations;

namespace _05.TestFormSubmission
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
            var formTitle = driver.FindElement(By.TagName("h2"));
            Assert.That(formTitle.Text, Is.EqualTo("Contact Form"));

            var maleButton = driver.FindElement(By.XPath("//input[@value='m']"));
            maleButton.Click();
            Assert.That(maleButton.Selected, Is.True);

            var firstName = driver.FindElement(By.Id("fname"));
            firstName.Clear();
            firstName.SendKeys("Butch");
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Butch"));

            var lastName = driver.FindElement(By.Id("lname"));
            lastName.Clear();
            lastName.SendKeys("Coolidge");
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Coolidge"));

            Assert.That(driver.FindElement(By.TagName("h3")).Displayed, Is.True);

            var phoneNumberField = driver.FindElement(By.CssSelector("div > p > input"));
            phoneNumberField.SendKeys("0888999777");
            Assert.That(phoneNumberField.GetAttribute("value"), Is.EqualTo("0888999777"));

            var checkbox = driver.FindElement(By.CssSelector("[type='checkbox']"));
            checkbox.Click();
            Assert.That(checkbox.Selected, Is.True);

            driver.FindElement(By.ClassName("button")).Click();

            Assert.That(driver.FindElement(By.TagName("h1")).Text, Is.EqualTo("Thank You!"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}