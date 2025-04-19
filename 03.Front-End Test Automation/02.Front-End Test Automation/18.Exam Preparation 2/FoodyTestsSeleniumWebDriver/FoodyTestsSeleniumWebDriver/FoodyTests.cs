using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FoodyTestsSeleniumWebDriver
{
    public class FoodyTests
    {
        private IWebDriver driver;

        private string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";
        private string username = "Orlin_Vladimirov";
        private string password = "P@r0la1122334455!";

        private string foodTitle = "";
        private string foodDescription = "";

        Random random;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//a[text()='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@name='Username']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Test, Order(1)]
        public void AddFoodWithInvalidData()
        {
            var invalidFoodTitle = "";
            var invalidFoodDescription = "";
            var errorMessage = "Unable to add this food revue!";

            driver.FindElement(By.XPath("//a[text()='Add Food']")).Click();
            driver.FindElement(By.XPath("//input[@name='Name']")).SendKeys(invalidFoodTitle);
            driver.FindElement(By.XPath("//input[@name='Description']")).SendKeys(invalidFoodDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            Assert.That(driver.Url, Is.EqualTo(baseUrl + "Food/Add"));
            var currentErrorMessage = driver.FindElement(By.XPath("//li[text()='Unable to add this food revue!']")).Text;
            Assert.That(currentErrorMessage, Is.EqualTo(errorMessage));
        }

        [Test, Order(2)]
        public void AddRandomFood()
        {          
            foodTitle = GenerateRandomString("title");
            foodDescription = GenerateRandomString("description");

            driver.FindElement(By.XPath("//a[text()='Add Food']")).Click();
            driver.FindElement(By.XPath("//input[@name='Name']")).SendKeys(foodTitle);
            driver.FindElement(By.XPath("//input[@name='Description']")).SendKeys(foodDescription);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == baseUrl);

            Assert.That(driver.Url, Is.EqualTo(baseUrl));

            var lastCreatedFood = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]"));
            var lastCreatedFoodTitle = lastCreatedFood.FindElement(By.XPath(".//h2")).Text;

            Assert.That(lastCreatedFoodTitle, Is.EqualTo(foodTitle));
        }

        [Test, Order(3)]
        public void EditLastAddedFood() 
        {
            var updatedTitle = GenerateRandomString("updated title");

            driver.Navigate().GoToUrl(baseUrl);           

            var allFoods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var lastCreatedFood = allFoods.Last();

            Actions actions = new Actions(driver);
            actions.ScrollToElement(lastCreatedFood.FindElement(By.XPath(".//a[text()='Edit']"))).Perform();
            lastCreatedFood.FindElement(By.XPath(".//a[text()='Edit']")).Click();

            var foodTitleInput = driver.FindElement(By.XPath("//input[@name='Name']"));
            foodTitleInput.Clear();
            foodTitleInput.SendKeys(updatedTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == baseUrl);

            lastCreatedFood = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]"));
            var lastCreatedFoodTitle = lastCreatedFood.FindElement(By.XPath(".//h2")).Text;

            Assert.That(lastCreatedFoodTitle, Is.EqualTo(foodTitle));
            Console.WriteLine("Title change won't be possible due to incomplete functionality.");
        }

        [Test, Order(4)]
        public void SearchForFoodTitle()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//input[@name='keyword']")).SendKeys(foodTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url == baseUrl + $"?keyword={foodTitle}");

            var resultsForSearchedFood = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var currentFoodTitle = driver.FindElement(By.XPath("//div[@class='row gx-5 align-items-center']//h2")).Text;

            Assert.That(resultsForSearchedFood.Count, Is.EqualTo(1));
            Assert.That(currentFoodTitle, Is.EqualTo(foodTitle));
        }

        [Test, Order(5)]
        public void DeleteLastAddedFood()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var allCreatedFoods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var foodCountBeforeDelete = allCreatedFoods.Count();
    
            var lastFood = driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]"));
            Actions actions = new Actions(driver);
            actions.ScrollToElement(lastFood).Perform();

            Assert.That(lastFood.Displayed, Is.True);

            var deleteButton = lastFood.FindElement(By.XPath(".//a[text()='Delete']"));
            deleteButton.Click();

            allCreatedFoods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var foodCountAfterDelete = allCreatedFoods.Count();           

            lastFood = allCreatedFoods.Last();
            var currentLastFoodTitle = lastFood.FindElement(By.XPath(".//h2")).Text;

            Assert.That(foodCountAfterDelete == foodCountBeforeDelete - 1);
            Assert.That(currentLastFoodTitle, Is.Not.EqualTo(foodTitle));
        }

        [Test, Order(6)]
        public void SearchForDeletedFood()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//input[@name='keyword']")).SendKeys(foodTitle);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//div[@class='p-5']//img")));

            var noFoodMessage = driver.FindElement(By.XPath("//div[@class='p-5']//h2"));
            var addFoodButton = driver.FindElement(By.XPath("//a[text()='Add food']"));

            Assert.That(noFoodMessage.Displayed, Is.True);
            Assert.That(noFoodMessage.Text, Is.EqualTo("There are no foods :("));
            Assert.That(addFoodButton.Displayed, Is.True);
        }

        public string GenerateRandomString(string input)
        {
            random = new Random();
            return input + random.Next(999, 9999).ToString();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}