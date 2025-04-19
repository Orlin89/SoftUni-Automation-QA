using NUnit.Framework;

using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class HomePageTest : BaseTests
    {

        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.Multiple(() =>
            {
                Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));
                Assert.That(page.GetPageHeadingText(), Is.EqualTo("Students Registry"));
            });
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen(), Is.True);

            homePage.Open();
            homePage.LinkAddStudentsPage.Click();
            Assert.That(new AddStudent(driver).IsOpen(), Is.True);


            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudents(driver).IsOpen(), Is.True);
        }
    }
}