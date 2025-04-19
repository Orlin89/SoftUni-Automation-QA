using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SummatorPOM
{
    public class SummatorPOM
    {
        private readonly AndroidDriver driver;

        public SummatorPOM(AndroidDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirtField => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));

        public IWebElement SecondField => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));

        public IWebElement CalcButton => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));

        public IWebElement Result => driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

        public string Calculator(string num1, string num2)
        {
            FirtField.Clear();
            FirtField.SendKeys(num1);
            SecondField.Clear();
            SecondField.SendKeys(num2);
            CalcButton.Click();

            return Result.Text;
        }
    }        
 }
