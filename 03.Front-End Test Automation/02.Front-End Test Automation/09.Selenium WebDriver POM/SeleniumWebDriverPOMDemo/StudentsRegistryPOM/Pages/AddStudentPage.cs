

using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "http://localhost:8080/add-student";

        public IWebElement ElementErrorMsg => driver.FindElement(By.XPath("//div[text()='Cannot add student. Name and email fields are required!']"));

        public IWebElement FieldStudentName => driver.FindElement(By.Id("name"));

        public IWebElement FieldStudentEmail => driver.FindElement(By.Id("email"));

        public IWebElement ButtonAdd => driver.FindElement(By.TagName("button"));

        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }

        public string GetErrorMsg()
        {
            return this.ElementErrorMsg.Text;
        }
    }
}
