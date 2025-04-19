using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Immutable;

namespace _04.WorkingWithAlerts
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [Test]
        public void HandleBasicAlert()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));
            alert.Accept();

            var result = driver.FindElement(By.Id("result"));
            Assert.That(result.Text, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        public void HandleConfirmAlert() 
        {
            // Click ok
            driver.FindElement(By.CssSelector("[onclick='jsConfirm()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"));

            alert.Accept();

            var result = driver.FindElement(By.Id("result"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Ok"));

            //Click cancel
            driver.FindElement(By.CssSelector("[onclick='jsConfirm()']")).Click();
            alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            Assert.That(result.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void HandlePromptAlert()
        {
            driver.FindElement(By.CssSelector("[onclick='jsPrompt()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"));

            alert.SendKeys("Hello");
            alert.Accept();

            var result = driver.FindElement(By.Id("result"));
            Assert.That(result.Text, Is.EqualTo("You entered: Hello"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}