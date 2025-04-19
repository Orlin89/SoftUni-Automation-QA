using System;
using NUnit.Framework;
using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class ViewStudentTest : BaseTests
    {

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var page = new ViewStudents(driver);
            page.Open();
            Assert.Multiple(() =>
            {
                Assert.That(page.GetPageTitle(), Is.EqualTo("Students"));
                Assert.That(page.GetPageHeadingText(), Is.EqualTo("Registered Students"));
            });
            var students = page.GetRegisterStudents();
            foreach (var st in students)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(st.IndexOf("(") > 0, Is.True);
                    Assert.That(st.LastIndexOf(")") == st.Length - 1, Is.True);
                });
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewStudentsPage = new ViewStudents(driver);

            viewStudentsPage.Open();
            viewStudentsPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            viewStudentsPage.Open();
            viewStudentsPage.LinkAddStudentsPage.Click();
            Assert.That(new AddStudent(driver).IsOpen(), Is.True);


            viewStudentsPage.Open();
            viewStudentsPage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudents(driver).IsOpen(), Is.True);
        }
    }
}