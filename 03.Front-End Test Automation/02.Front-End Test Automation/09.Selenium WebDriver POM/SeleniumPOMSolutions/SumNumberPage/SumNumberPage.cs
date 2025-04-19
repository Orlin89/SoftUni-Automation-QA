using OpenQA.Selenium;


namespace SumNumberPage
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().
                ImplicitWait = TimeSpan.FromSeconds(2);
        }

        const string PageUrl =
            "http://localhost:8080/sum-num.html";

        public IWebElement FieldNum1 => 
            driver.FindElement(By.CssSelector("input#number1"));
        public IWebElement FieldNum2 => 
            driver.FindElement(By.CssSelector("input#number2"));
        public IWebElement ButtonCalc => 
            driver.FindElement(By.CssSelector("#calcButton"));
        public IWebElement ButtonReset => 
            driver.FindElement(By.CssSelector("#resetButton"));
        public IWebElement ElementResult => 
            driver.FindElement(By.CssSelector("#result"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public void ResetForm()
        {
            ButtonReset.Click();
        }

        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + 
                ElementResult.Text == "";
        }

        public string AddNumbers(string num1, string num2)
        {
            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            ButtonCalc.Click();
            string result = ElementResult.Text;
            return result;
        }
    }
}
