using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace IdeaCenterSeleniumWebDriver
{
    public class IdeaCenterTests
    {
        private IWebDriver driver;
        private string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/";
        private string email = "prien@abv.bg";
        private string password = "P@r0la1122334455!";

        private string title = "";
        private string description = "";

        Random random;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2']")).Click();
            driver.FindElement(By.XPath("//input[@name='Email']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']")).Click();
        }

        [Test, Order(1)]
        public void CreateIdeaWithInvalidData()
        {
            var invalidTitle = "";
            var invalidDescription = "";

            driver.FindElement(By.XPath("//a[text()='Create Idea']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(invalidTitle);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(invalidDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var errorMesage = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;
            Assert.That(driver.Url, Is.EqualTo(baseUrl + "Ideas/Create"));
            Assert.That(errorMesage, Is.EqualTo("Unable to create new Idea!"));
        }

        [Test, Order(2)]
        public void CreateRandomIdea()
        {
            title = GenerateRandomString("title");
            description = GenerateRandomString("description");

            driver.FindElement(By.XPath("//a[text()='Create Idea']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(title);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(description);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var lastCreatedIdea = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]"));
            var lastCreatedIdeaDescription = lastCreatedIdea.FindElement(By.XPath(".//p")).Text;

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "Ideas/MyIdeas"));
            Assert.That(lastCreatedIdeaDescription.Trim(), Is.EqualTo(description));
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdea()
        {
            driver.FindElement(By.XPath("//a[text()='My Ideas']")).Click();
            var allIdeaCart = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
            var lastIdeaCart = allIdeaCart.Last();
            var viewButton = lastIdeaCart.FindElement(By.XPath(".//a[text()='View']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(viewButton).Perform();

            viewButton.Click();

            var currentTitle = driver.FindElement(By.XPath("//h1")).Text;

            Assert.That(currentTitle, Is.EqualTo(title));
        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTitle()
        {
            var changedTitle = GenerateRandomString("Changed Title");

            driver.FindElement(By.XPath("//a[text()='My Ideas']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromMicroseconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")));

            var lastCreatedIdea = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]"));
            var editButton = lastCreatedIdea.FindElement(By.XPath(".//a[text()='Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();
            //editButton.Click();

            var inputTitleField = driver.FindElement(By.XPath("//input[@name='Title']"));
            inputTitleField.Clear();
            inputTitleField.SendKeys(changedTitle);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            
            driver.Navigate().GoToUrl(baseUrl + "Ideas/MyIdeas");
            wait.Until(d => d.Url == baseUrl + "Ideas/MyIdeas");

            //ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));

            var allIdeaCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
            var lastIdeaCard = allIdeaCards.Last();
            //var viewButton = lastIdeaCard.FindElement(By.XPath(".//a[text()='View']"));
            actions.MoveToElement(lastIdeaCard.FindElement(By.XPath(".//a[text()='View']"))).Click().Perform();

            var currentTitle = driver.FindElement(By.XPath("//h1")).Text;

            Assert.That(currentTitle, Is.EqualTo(changedTitle));
        }

        [Test, Order(5)]
        public void EditIdeaDescription()
        {
            var changedDescription = GenerateRandomString("Changed Description");
            description = changedDescription;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseUrl + "Ideas/MyIdeas");
            wait.Until(d => d.Url == baseUrl + "Ideas/MyIdeas");

            var lastIdeaCard = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]"));
            var editButton = lastIdeaCard.FindElement(By.XPath(".//a[text()='Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            var descriptionFieldInput = driver.FindElement(By.XPath("//textarea"));
            descriptionFieldInput.Clear();
            descriptionFieldInput.SendKeys(changedDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            driver.Navigate().GoToUrl(baseUrl + "Ideas/MyIdeas");
            wait.Until(d => d.Url == baseUrl + "Ideas/MyIdeas");

            lastIdeaCard = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]"));
            var lastIdeaDescription = lastIdeaCard.FindElement(By.XPath(".//p")).Text;

            Assert.That(lastIdeaDescription, Is.EqualTo(changedDescription));
        }

        [Test, Order(6)]
        public void DeleteLastIdea()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseUrl + "Ideas/MyIdeas");
            wait.Until(d => d.Url == baseUrl + "Ideas/MyIdeas");

            var lastIdeaCard = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(lastIdeaCard.FindElement(By.XPath(".//a[text()='Delete']"))).Click().Perform();

            var allIdeaCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

            bool isCardDeleted = allIdeaCards.All(card => !card.Text.Contains(description));

            Assert.That(isCardDeleted, Is.True);
        }

        private string GenerateRandomString(string text)
        {
            random = new Random();
            return text + random.Next(999, 9999).ToString();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}