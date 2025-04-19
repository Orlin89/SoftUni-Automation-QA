using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SelenoidTest
{
    [TestFixture("chrome", "126.0")]
    [TestFixture("firefox", "125.0")]
    public class SelenoidTest
    {
        private IWebDriver driver;

        private string browserType;
        private string version;
        public SelenoidTest(string browserType, string version)
        {
            this.browserType = browserType;
            this.version = version;
        }

        [SetUp]
        public void SetUp()
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
                var options = new ChromeOptions();
                options.BrowserVersion = version;

                options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                {
                    ["name"] = "Chrome browser tests...",
                    ["sessionTimeout"] = "15m",
                    ["labels"] = new Dictionary<string, object>
                    {
                        ["manual"] = "false"
                    },
                    ["enableVideo"] = false,
                    ["enableVNC"] = true
                });

                return options;
            }
            else
            {
                var options = new FirefoxOptions();
                options.BrowserVersion = version;

                options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                {
                    ["name"] = "FireFox browser tests...",
                    ["sessionTimeout"] = "15m",
                    ["labels"] = new Dictionary<string, object>
                    {
                        ["manual"] = "false"
                    },
                    ["enableVideo"] = false,
                    ["enableVNC"] = true
                });
                return options;
            }
        }

        [Test]
        public void GetTitleOfQAArticle()
        {
            var searchValue = "Quality Assurance";
            var expected = "Quality assurance";

            this.driver.FindElement(By.ClassName("cdx-text-input__input")).SendKeys(searchValue);

            this.driver.FindElement(By.ClassName("cdx-search-input__end-button")).Click();

            var titleText = this.driver.FindElement(By.CssSelector("h1 span")).Text;

            Assert.That(expected, Is.EqualTo(titleText));
        }

        [Test]
        public void CheckLogoFunctionality()
        {
            var expected = "Welcome to Wikipedia";

            this.driver.FindElement(By.ClassName("mw-logo")).Click();

            var wellcomeMsg = this.driver.FindElement(By.Id("Welcome_to_Wikipedia")).Text;

            Assert.That(expected, Is.EqualTo(wellcomeMsg));
        }



        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}