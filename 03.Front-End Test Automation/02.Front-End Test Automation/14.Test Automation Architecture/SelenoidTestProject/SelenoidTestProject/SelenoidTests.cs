using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Browser;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SelenoidTestProject
{
    [TestFixture("chrome", "127.0")]
    [TestFixture("firefox", "125.0")]

    public class SelenoidTests
    {
        private IWebDriver driver;
        private string browserType;
        private string version;

        public SelenoidTests(string browserType, string version)
        {
            this.browserType = browserType;
            this.version = version;
        }

        [SetUp]
        public void Setup()
        {
            var options = GetOptions(this.browserType, this.version);

            this.driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

            this.driver.Url = "https://en.wikipedia.org/";

            this.driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);      
        }

        private DriverOptions GetOptions(string browserType, string version)
        {
            if (browserType == "chrome")
            {
                ChromeOptions options = new ChromeOptions();
                options.BrowserVersion = "127.0";
                options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                {
                    /* How to add test badge */
                    ["name"] = "Test badge...",

                    /* How to set session timeout */
                    ["sessionTimeout"] = "15m",

                    /* How to set timezone */
                    ["env"] = new List<string>() {
        "TZ=UTC"
    },

                    /* How to add "trash" button */
                    ["labels"] = new Dictionary<string, object>
                    {
                        ["manual"] = "true"
                    },

                    /* How to enable video recording */
                    ["enableVideo"] = true
                });

                return options;
            }
            else
            {
                FirefoxOptions options = new FirefoxOptions();
                options.BrowserVersion = "125.0";
                options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                {
                    /* How to add test badge */
                    ["name"] = "Test badge...",

                    /* How to set session timeout */
                    ["sessionTimeout"] = "15m",

                    /* How to set timezone */
                    ["env"] = new List<string>() {
        "TZ=UTC"
    },

                    /* How to add "trash" button */
                    ["labels"] = new Dictionary<string, object>
                    {
                        ["manual"] = "true"
                    },

                    /* How to enable video recording */
                    ["enableVideo"] = true
                });

                return options;
            }
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://en.wikipedia.org/");
            var typeField = driver.FindElement(By.CssSelector("#searchInput"));
            typeField.SendKeys("Quality Assurance");
            driver.FindElement(By.XPath("//form[@id='searchform']//button")).Click();
            var pageTitle = driver.FindElement(By.XPath("//h1[@id='firstHeading']//span"));

            Assert.That(pageTitle.Text, Is.EqualTo("Quality assurance"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}