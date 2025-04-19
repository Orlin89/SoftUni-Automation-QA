using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _04.Data_DrivenTests
{
    public class Task4Tests
    {
        IWebDriver driver;

        IWebElement textBoxFirstNumber;
        IWebElement textBoxSecondNumber;
        IWebElement dropDownOption;
        IWebElement calcBtn;
        IWebElement resetBtn;
        IWebElement divResult;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("file:///B:/Front-End%20Test%20Automation/06.Exercise%20Selenium%20WebDriver/number-calculator/number-calculator.html");

            textBoxFirstNumber = driver.FindElement(By.Id("number1"));
            textBoxSecondNumber = driver.FindElement(By.Id("number2"));
            dropDownOption = driver.FindElement(By.Id("operation"));
            calcBtn = driver.FindElement(By.Id("calcButton"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));
        }

        public void Calculate(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            resetBtn.Click();

            if(!string.IsNullOrEmpty(firstNumber))
            {
                textBoxFirstNumber.SendKeys(firstNumber);
            }

            if(!string.IsNullOrEmpty(secondNumber))
            {
                textBoxSecondNumber.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOption).SelectByText(operation);
            }

            calcBtn.Click();

            Assert.That(divResult.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("5", "+ (sum)", "5", "Result: 10")]
        [TestCase("30", "+ (sum)", "4", "Result: 34")]
        [TestCase("5", "- (subtract)", "5", "Result: 0")]
        [TestCase("20", "- (subtract)", "3", "Result: 17")]
        [TestCase("5", "* (multiply)", "5", "Result: 25")]
        [TestCase("2", "* (multiply)", "4", "Result: 8")]
        [TestCase("5", "/ (divide)", "5", "Result: 1")]
        [TestCase("20", "/ (divide)", "2", "Result: 10")]
        public void TestNumberCalculations(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            Calculate(firstNumber, operation, secondNumber, expectedResult); 
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}