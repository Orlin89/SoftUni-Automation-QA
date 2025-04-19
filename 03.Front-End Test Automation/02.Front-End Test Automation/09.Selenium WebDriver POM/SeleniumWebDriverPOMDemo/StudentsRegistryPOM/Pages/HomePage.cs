

using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://localhost:8080/";

        public IWebElement ElementStudentsCount => driver.FindElement(By.XPath("//p//b"));

        public int GetStudentsCount()
        {
            string studentsCountText = this.ElementStudentsCount.Text;
            return int.Parse(studentsCountText);
        }
    }

}
