using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace _02.FirstTest
{
    public class Tests      
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://nakov.com");
            var windowTitle = driver.Title;

            Assert.That(windowTitle.Contains("Svetlin Nakov – Official Web Site"));

            Console.WriteLine(windowTitle);

            var searchBar = driver.FindElement(By.ClassName("smoothScroll"));

            Assert.That(searchBar.Text, Does.Contain("SEARCH"));

            searchBar.Click();

            var message = driver.FindElement(By.Id("s"));

            var placeholderText = message.GetAttribute("placeholder");

            Assert.That(placeholderText, Is.EqualTo("Search this site"));

            Console.WriteLine(placeholderText);

        }

        [TearDown]
        public void TearDown() 
        {
            driver.Dispose();
        }
    }
}