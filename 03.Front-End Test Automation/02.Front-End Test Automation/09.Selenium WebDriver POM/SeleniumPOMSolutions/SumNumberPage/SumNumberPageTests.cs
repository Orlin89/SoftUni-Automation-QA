using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace SumNumberPage
{
    public class SumNumberPageTests
    {
        private ChromeDriver driver;
        //private SumNumberPage sumpage;

        [SetUp]
        public void Setup()
        {
           //var chromeDriverPath = @"C:\Program Files\ChromeDriver\chromedriver.exe"; // Replace with the actual path
            driver = new ChromeDriver();
            //sumpage = new SumNumberPage(driver);
            //sumpage.OpenPage();
        }

        [TearDown]
        public void Close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }


        [Test]
        public void Test_Valid_Numbers()
        {
            var sumpage = new SumNumberPage(driver);
            sumpage.OpenPage();
            var result = sumpage.AddNumbers("5", "6");
            Assert.That(result, Is.EqualTo("Sum: 11"));
        }

        [Test]
        public void Test_AddTwoNumbers_Invalid()
        {
            var sumpage = new SumNumberPage(driver);
            sumpage.OpenPage();
            string resultText = sumpage.AddNumbers("hello", "world");
            Assert.That(resultText, Is.EqualTo("Sum: invalid input"));
        }

        [Test]
        public void Test_AddTwoNumbers_Reset()
        {
            var sumpage = new SumNumberPage(driver);
            sumpage.OpenPage();
            sumpage.AddNumbers("5", "7");
            bool isFormEmpty = sumpage.IsFormEmpty();
            Assert.That(isFormEmpty, Is.False);
            sumpage.ResetForm();
            isFormEmpty = sumpage.IsFormEmpty();
            Assert.That(isFormEmpty, Is.True);
        }


    }
}
