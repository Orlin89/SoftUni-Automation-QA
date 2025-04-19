using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TestProjects
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [TestFixture("firefox")]
    public class PracticeProjectTests
    {
        private IWebDriver driver;
        private int random;

        private string browserType;
        public PracticeProjectTests(string browserType)
        {
            this.browserType = browserType;
        }

        [SetUp]
        public void SetUp()
        {
            var options = GetOptions(this.browserType);

            this.driver = new RemoteWebDriver(new Uri("http://192.168.1.104:4444"), options);

            this.driver.Url = "https://localhost:7194/";
        }

        private DriverOptions GetOptions(string browserType)
        {
            if(browserType == "chrome")
            {
                return new ChromeOptions();
            }
            else if(browserType == "edge")
            {
                return new EdgeOptions();
            }
            else
            {
                return new FirefoxOptions();
            }
        }

        [Test]
        public void CheckWelcomeMessageTitle()
        {
            var welcomeMsg = this.driver.FindElement(By.Id("welcome-msg")).Text;
            Assert.That(welcomeMsg, Is.EqualTo("Welcome to Test Practice Application"));
        }

        [Test]
        public void GoToCreateEntityPageFromNavBarAndCreateNewEntity()
        {
            this.driver.FindElement(By.CssSelector(".nav-item .nav-link[href=\"/Entities/Create\"]")).Click();

            var random = new Random();
            this.random = random.Next(1, 200_000);

            var expectedName = $"Test_name{this.random}";
            var expectedDescription = "Random Description...";
            var expectedAuthor = $"Author_{this.random}";
            var expectedCount = "198887";
            var expectedStatus = "Four"; 

            this.driver.FindElement(By.Id("name")).SendKeys(expectedName);
            this.driver.FindElement(By.Id("description")).SendKeys(expectedDescription);
            this.driver.FindElement(By.Id("author")).SendKeys(expectedAuthor);
            this.driver.FindElement(By.Id("count")).Clear();
            this.driver.FindElement(By.Id("count")).SendKeys(expectedCount);

            var selectElement = driver.FindElement(By.Id("status"));
            var select = new SelectElement(selectElement);
            select.SelectByText(expectedStatus);

            this.driver.FindElement(By.Id("createBtn")).Click();

            var tableRow = this.driver.FindElement(By.CssSelector("table tbody tr:last-child"));

            var actualName = tableRow.FindElement(By.ClassName("entity_name")).Text;
            var actualDescription = tableRow.FindElement(By.ClassName("entity_description")).Text;
            var actualAuthor = tableRow.FindElement(By.ClassName("entity_author")).Text;
            var actualStatus = tableRow.FindElement(By.ClassName("entity_status")).Text;
            var actualCount = tableRow.FindElement(By.ClassName("entity_count")).Text;

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualDescription, Is.EqualTo(expectedDescription));
            Assert.That(actualAuthor, Is.EqualTo(expectedAuthor));
            Assert.That(actualStatus, Is.EqualTo(expectedStatus));
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [TearDown]
        public void TearDown() 
        { 
            driver.Close();
        }
    }
}
