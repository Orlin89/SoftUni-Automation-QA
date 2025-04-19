using NUnit.Framework;
using StudentsRegistryPOM.Pages;
using System;
using System.Linq;


namespace StudentsRegistryPOM.Tests
{
    public class AddStudentsPageTest : BaseTests
    {
        [Test]
        public void Test_AddStudentsPage_Content()
        {
            var page = new AddStudent(driver);
            page.Open();
            Assert.Multiple(() =>
            {
                Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));
                Assert.That(page.GetPageHeadingText(), Is.EqualTo("Register New Student"));
                Assert.That(page.FieldName.Text, Is.EqualTo(""));
                Assert.That(page.FieldEmail.Text, Is.EqualTo(""));
                Assert.That(page.ButtonSubmit.Text, Is.EqualTo("Add"));
            });
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            
            var addStudentsPage = new AddStudent(driver);

            addStudentsPage.Open();
            addStudentsPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            addStudentsPage.Open();
            addStudentsPage.LinkAddStudentsPage.Click();
            Assert.That(new AddStudent(driver).IsOpen(), Is.True);


            addStudentsPage.Open();
            addStudentsPage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudents(driver).IsOpen(), Is.True);
        }

        [Test]
        public void Test_AddStudentsPage_AddValidStudent()
        {
            var page = new AddStudent(driver);
            page.Open();

            // Generate random name and email
            string name = GenerateRandomName();
            string email = GenerateRandomEmail(name);

            page.AddStudents(name, email);
            var viewStudents = new ViewStudents(driver);
            viewStudents.Open();
            Assert.That(viewStudents.IsOpen(), Is.True);
            var students = viewStudents.GetRegisterStudents();
            string newStudent = name + " (" + email + ")";
            Assert.That(students, Does.Contain(newStudent));
        }

        [Test]
        public void Test_AddStudentsPage_AddInvalidStudent()
        {
            var page = new AddStudent(driver);
            page.Open();
            string name = "";
            string email = "mario@gmail.com";
            page.AddStudents(name, email);
            Assert.Multiple(() =>
            {
                Assert.That(page.IsOpen(), Is.True);
                Assert.That(page.ErrorMessageElement.Text, Does.Contain("Cannot add student."));
            });
        }
        // Method to generate a random name
        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Mario", "Luigi", "Peach", "Toad", "Yoshi" };
            return names[random.Next(names.Length)] + random.Next(1000, 9999).ToString();
        }

        // Method to generate a random email
        private string GenerateRandomEmail(string name)
        {
            var random = new Random();
            string domain = "@gmail.com";
            return name.ToLower() + random.Next(1000, 9999).ToString() + domain;
        }
    }
}
