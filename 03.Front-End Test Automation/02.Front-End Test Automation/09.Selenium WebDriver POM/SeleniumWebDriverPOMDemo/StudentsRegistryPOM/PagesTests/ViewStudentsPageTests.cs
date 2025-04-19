using StudentsRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsRegistryPOM.PagesTests
{
    public class ViewStudentsPageTests : BaseTests
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();

            Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewStudentsPage.GetPageHeadingText, Is.EqualTo("Registered Students"));

            var students = viewStudentsPage.GetStudentsList();
            foreach (var student in students)
            {
                Assert.That(student.IndexOf("(") > 0);
                Assert.That(student.IndexOf(")") == student.Length - 1);


            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();

            viewStudentsPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            viewStudentsPage.Open();
            viewStudentsPage.LinkViewStudentsPage.Click();
            Assert.That(viewStudentsPage.IsOpen(), Is.True);

            viewStudentsPage.Open();
            viewStudentsPage.LinkAddStudentsPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen(), Is.True);
        }
    }
}
