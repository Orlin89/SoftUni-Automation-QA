

using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace StudentsRegistryPOM.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://localhost:8080/students";

        ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.XPath("//ul//li"));

        public string[] GetStudentsList()
        {
            var elementsStudents = this.ListItemsStudents.Select(s => s.Text).ToArray(); 
            return elementsStudents;
        }
    }
}
