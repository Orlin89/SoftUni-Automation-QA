using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumTwoNumbers
{
    public class SumNumberPageTests
    {
        IWebDriver driver;
        private SumNumberPage sumPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
        }

        [Test]
        public void Test_AddTwoNumbers_ValidInput()
        { 
            var result = sumPage.AddNumbers("10", "10");
            Assert.That(result, Is.EqualTo("Sum: 20"));

            // Assert.That(sumPage.AddNumbers("10", "10"), Is.EqualTo("Sum: 20"));
        }

        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {
            sumPage.AddNumbers("InvalidInput", "10");
            Assert.That(sumPage.ElementResult.Text, Is.EqualTo("Sum: invalid input"));

            // Assert.That(sumPage.AddNumbers("InvalidInput", "10"), Is.EqualTo("Sum: invalid input"));
        }

        [Test]
        public void Test_FormReset()
        {
            sumPage.ResetForm();
            Assert.That(sumPage.IsFormEmpty(), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
