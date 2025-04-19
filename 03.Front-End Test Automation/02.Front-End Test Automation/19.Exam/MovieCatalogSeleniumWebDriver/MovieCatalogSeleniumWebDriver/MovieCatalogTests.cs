using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace MovieCatalogSeleniumWebDriver
{
    public class MovieCatalogTests
    {
        IWebDriver driver;
        private string baseUrl = "https://d24hkho2ozf732.cloudfront.net/";
        private string email = "prien@abv.bg";
        private string password = "P@r0la1122334455!";
        private string randomMovieTitle = "";
        private string randomMovieDescription = "";

        Random random;
        Actions actions;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();           

            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//li[@class='nav-item']//a[text()='Login']")).Click();
            actions = new Actions(driver);           
            actions.ScrollToElement(driver.FindElement(By.XPath("//a[@href='/User/Login']"))).Perform();
           
            driver.FindElement(By.XPath("//a[@href='/User/Login']")).Click();
            driver.FindElement(By.XPath("//input[@name='Email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[text()='Login']")).Click();           
        }

        [Test, Order(1)]
        public void AddMovieWithoutTitle()
        {                 
            driver.FindElement(By.XPath("//a[@href='/Catalog/Add#add']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys("");
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//textarea")).SendKeys("Some description");
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            var currentErrorMessage = driver.FindElement(By.XPath("//div[@class='toast toast-error']"));
            Assert.That(currentErrorMessage.Displayed, Is.True);
            Assert.That(currentErrorMessage.Text, Is.EqualTo("The Title field is required."));
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescription()
        {
            randomMovieTitle = GenerateRandomString("Title");
            
            driver.Navigate().GoToUrl(baseUrl);           

            driver.FindElement(By.XPath("//a[@href='/Catalog/Add#add']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomMovieTitle);
            driver.FindElement(By.XPath("//textarea")).Clear();
            driver.FindElement(By.XPath("//textarea")).SendKeys("");
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            var currentErrorMessage = driver.FindElement(By.XPath("//div[@class='toast toast-error']"));
            Assert.That(currentErrorMessage.Displayed, Is.True);
            Assert.That(currentErrorMessage.Text, Is.EqualTo("The Description field is required."));
        }

        [Test, Order(3)]
        public void AddMovieWithRandomTitle()
        {
            randomMovieTitle = GenerateRandomString("TITLE");
            randomMovieDescription = GenerateRandomString("Description");

            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//a[@href='/Catalog/Add#add']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomMovieTitle);
            driver.FindElement(By.XPath("//textarea")).Clear();
            driver.FindElement(By.XPath("//textarea")).SendKeys(randomMovieDescription);
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            NavigateToLastPage();
            VerifyLastMovieTitle(randomMovieTitle);

            // var lastMovieAdded = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]"));
            // var lastMovieTitle = lastMovieAdded.FindElement(By.XPath(".//h2")).Text;

            // Assert.That(lastMovieTitle, Is.EqualTo(randomMovieTitle));
        }

        [Test, Order(4)]
        public void EditLastAddedMovie()
        {
            randomMovieTitle = GenerateRandomString("EDITED");

            driver.FindElement(By.XPath("//a[text()='All Movies']")).Click();

            NavigateToLastPage();
            var lastMovieAdded = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]"));
            var editButton = lastMovieAdded.FindElement(By.XPath(".//a[text()='Edit']"));
            editButton.Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomMovieTitle);
            driver.FindElement(By.XPath("//button[text()='Edit']")).Click();

            var currentMessage = driver.FindElement(By.XPath("//div[@class='toast toast-success']"));
            Assert.That(currentMessage.Displayed, Is.True);
            Assert.That(currentMessage.Text, Is.EqualTo("The Movie is edited successfully!"));
        }

        [Test, Order(5)]
        public void MarkLastAddedMovieAsWatched()
        {
            driver.FindElement(By.XPath("//a[text()='All Movies']")).Click();
            NavigateToLastPage();
            var lastMovieAdded = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]"));
            var markAsWatchedButton = lastMovieAdded.FindElement(By.XPath(".//a[text()='Mark as Watched']"));
            markAsWatchedButton.Click();
            driver.FindElement(By.XPath("//a[text()='Watched Movies']")).Click();

            NavigateToLastPage();

            VerifyLastMovieTitle(randomMovieTitle);
        }

        [Test, Order(6)]
        public void DeleteLastAddedMovie()
        {
            driver.FindElement(By.XPath("//a[text()='All Movies']")).Click();
            NavigateToLastPage();
            var lastMovieAdded = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]"));
            var deleteButton = lastMovieAdded.FindElement(By.XPath(".//a[text()='Delete']"));
            deleteButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//button[text()='Yes']")));
            driver.FindElement(By.XPath("//button[text()='Yes']")).Click();

            var currentMessage = driver.FindElement(By.XPath("//div[@class='toast toast-success']")).Text;
            Assert.That(currentMessage, Is.EqualTo("The Movie is deleted successfully!"));
        }



        private void NavigateToLastPage()
        {           
            var paginationItems = driver.FindElements(By.CssSelector("ul.pagination li.page-item"));
            var lastPageItem = paginationItems.Last();
            
            actions.MoveToElement(lastPageItem).Perform();
           
            var lastPageLink = lastPageItem.FindElement(By.CssSelector("a.page-link"));
            lastPageLink.Click();
        }

        private void VerifyLastMovieTitle(string expectedTitle)
        {           
            var movies = driver.FindElements(By.CssSelector(".col-lg-4"));
            var lastMovieElement = movies.Last();
            var lastMovieElementTitle = lastMovieElement.FindElement(By.CssSelector("h2"));
           
            string actualMovieTitle = lastMovieElementTitle.Text.Trim();
            Assert.That(actualMovieTitle, Is.EqualTo(expectedTitle), "The last movie title does not match the expected value.");
        }

        private string GenerateRandomString(string input)
        {
            random = new Random();
            return input + random.Next(999, 9999).ToString();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}