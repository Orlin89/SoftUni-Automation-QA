
using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.PagesTests
{
    public class HomePageTests : BaseTests
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Students Registry"));

            page.GetStudentsCount();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var page = new HomePage(driver);
            page.Open();
            page.LinkHomePage.Click();
            Assert.That(page.IsOpen(), Is.True);

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen(), Is.True);

            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen(), Is.True);
        }
    }
}
