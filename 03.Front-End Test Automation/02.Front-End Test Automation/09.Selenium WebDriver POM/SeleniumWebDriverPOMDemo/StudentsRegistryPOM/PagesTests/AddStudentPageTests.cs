using StudentsRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsRegistryPOM.PagesTests
{
    public class AddStudentPageTests : BaseTests
    {

        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
            Assert.That(addStudentPage.FieldStudentName.Text, Is.EqualTo(""));
            Assert.That(addStudentPage.FieldStudentEmail.Text, Is.EqualTo(""));
            Assert.That(addStudentPage.ButtonAdd.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            var addStudenPage = new AddStudentPage(driver);
            addStudenPage.Open();

            addStudenPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            addStudenPage.Open();
            addStudenPage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);

            addStudenPage.Open();
            addStudenPage.LinkAddStudentsPage.Click();
            Assert.That(addStudenPage.IsOpen(), Is.True);
        }

        [Test]
        public void Test_AddStudentPage_AddValidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = "New Student" + DateTime.Now.Ticks;
            string email = "emalil" + DateTime.Now.Ticks + "@gmail.com";

            addStudentPage.AddStudent(name, email);

            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.That(viewStudentsPage.IsOpen(), Is.True);

            var studentsList = viewStudentsPage.GetStudentsList();

            Assert.That(studentsList[studentsList.Length - 1].Contains(name));

            // string newStudent = name + " (" + email + ")";
            // Assert.That(studentsList, Does.Contain(newStudent));
        }

        [Test]
        public void Test_AddStudentPage_AddInvalidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = "";
            string email = "orlin@gmail.com";
            addStudentPage.AddStudent(name, email);

            Assert.That(addStudentPage.IsOpen, Is.True);
            Assert.That(addStudentPage.ElementErrorMsg.Text, Is.EqualTo("Cannot add student. Name and email fields are required!"));
            addStudentPage.GetErrorMsg();
        }
    }
}
