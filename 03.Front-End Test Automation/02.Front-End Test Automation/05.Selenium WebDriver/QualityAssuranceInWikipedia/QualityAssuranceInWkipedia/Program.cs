using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QualityAssuranceInWkipedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://wikipedia.org");

            Console.WriteLine("Main page title: " +  driver.Title);

            var searchBox = driver.FindElement(By.Id("searchInput"));

            searchBox.Click();

            searchBox.SendKeys("Quality Assurance" + Keys.Enter);

            Console.WriteLine("Quality A page title: " + driver.Title);
            
            driver.Dispose();
        }
    }
}
