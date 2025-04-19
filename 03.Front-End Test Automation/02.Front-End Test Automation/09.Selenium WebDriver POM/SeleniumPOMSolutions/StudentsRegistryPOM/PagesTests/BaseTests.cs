using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class BaseTests
    { 
   protected IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
            
            this.driver = new ChromeDriver();
        }

    [OneTimeTearDown]
    public void ShutDown()
    {
        driver.Quit();
        driver.Dispose();
        }
}
}
