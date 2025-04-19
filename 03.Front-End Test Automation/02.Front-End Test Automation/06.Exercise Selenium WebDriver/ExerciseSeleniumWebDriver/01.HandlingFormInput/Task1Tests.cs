using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _01.HandlingFormInput
{
    public class Task1Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();
            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            driver.FindElement(By.XPath("//input[@value='m']")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys("firstTestName");
            driver.FindElement(By.Name("lastname")).SendKeys("lastTestName");
            driver.FindElement(By.Id("dob")).SendKeys("03.11.2003" + Keys.Enter);

            Random random = new Random();
            int number = random.Next(1000, 9999);
            string email = "someEmail" + number.ToString() + "@gmail.com";

            driver.FindElement(By.Name("email_address")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name='company']")).SendKeys("Some company");
            driver.FindElement(By.Name("street_address")).SendKeys("Vitoshka");
            driver.FindElement(By.Name("suburb")).SendKeys("Sofia");
            driver.FindElement(By.Name("postcode")).SendKeys("1000");
            driver.FindElement(By.Name("city")).SendKeys("Sofia");
            driver.FindElement(By.Name("state")).SendKeys("Sofia");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            driver.FindElement(By.Name("telephone")).SendKeys("0896574378");
            driver.FindElement(By.Name("newsletter")).Click();
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.Name("confirmation")).SendKeys("123456");
            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            Assert.That(driver.FindElement(By.TagName("h1")).Text, Is.EqualTo("Your Account Has Been Created!"));

            driver.FindElement(By.XPath("//span[text()='Log Off']")).Click();
            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            Console.WriteLine("User Account Created with email: " + email);
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}