using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _03.Drop_downPractice
{
    public class Task3Tests
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
            string path = Directory.GetCurrentDirectory() + "/manufacturers.txt";

            if(File.Exists(path))
            {
                File.Delete(path);
            }

            SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
            IList<IWebElement> dropDownOptions = dropDown.Options;
            List<string> optionNames = new List<string>();

            foreach (var option in dropDownOptions)
            {
                optionNames.Add(option.Text);
            }
            optionNames.RemoveAt(0);

            foreach (var currentOption in optionNames)
            {
                dropDown.SelectByText(currentOption);
                dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {currentOption} has no products\n");
                }
                else
                {
                    IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));
                    File.AppendAllText(path, $"\n\nThe manufacturer {currentOption} products are listed--\n");

                    var rows = productTable.FindElements(By.XPath("//tbody//tr"));

                    foreach (var row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }
                }
            }
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}