using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02.WorkingWithWebTables
{
    public class Task2Tests
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
            // path to save csv file
            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";
            if (File.Exists(path))
            {
                File.Delete(path); 
            }



            var table = driver.FindElement(By.TagName("table"));
            var tableRows = table.FindElements(By.XPath("//tbody//tr"));

            foreach (var row in tableRows)
            {
                var items = row.FindElements(By.TagName("td"));

                foreach (var item in items)
                {
                    string itemData = item.Text;
                    string[] productInfo = itemData.Split('\n');
                    string productInfoToSave = productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n";

                    // write product information to the file
                    File.AppendAllText(path, productInfoToSave);
                }
            }

            Assert.That(File.Exists(path), Is.True, "CSV file was not created.");
            Assert.That(new FileInfo(path).Length, Is.GreaterThan(0), "CSV file is empty.");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}