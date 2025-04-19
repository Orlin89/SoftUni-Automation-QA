using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumTwoNumbers
{
    

    public class SumNumberPage 
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FieldNum1 => driver.FindElement(By.CssSelector("input#number1"));
        public IWebElement FieldNum2 => driver.FindElement(By.CssSelector("input#number2"));
        public IWebElement ButtonCalc => driver.FindElement(By.CssSelector("#calcButton"));
        public IWebElement ButtonReset => driver.FindElement(By.CssSelector("#resetButton"));
        public IWebElement ElementResult => driver.FindElement(By.CssSelector("#result"));


        public void OpenPage()
        {
            driver.Navigate().GoToUrl("file:///B:/Front-End%20Test%20Automation/09.Selenium%20WebDriver%20POM/Resources/Sum-Num/sum-num.html");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public string AddNumbers(string num1, string num2)
        {
            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            ButtonCalc.Click();

            string result = ElementResult.Text;
            return result;
        }

        public void ResetForm()
        {
            ButtonReset.Click();
        }

        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ElementResult.Text == "";
        }
        
    }
}
