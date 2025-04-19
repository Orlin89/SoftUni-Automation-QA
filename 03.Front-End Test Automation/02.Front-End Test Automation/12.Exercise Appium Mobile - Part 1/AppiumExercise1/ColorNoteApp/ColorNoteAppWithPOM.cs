using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteApp
{
    public class ColorNoteAppWithPOM
    {
        private AndroidDriver driver;
        private ColorNoteAppPage page;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UIAutomator2",
                DeviceName = "AppiumDeviceName",
                App = "B:\\Front-End Test Automation\\12.Exercise Appium Mobile - Part 1\\Resources\\Notepad.apk"
            };

            androidOptions.AddAdditionalAppiumOption("autoGrantPermissions", true);

            // Use the existing Appium server URL

            driver = new AndroidDriver(new Uri("http://127.0.0.1:4723"), androidOptions);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            page = new ColorNoteAppPage(driver);
        }

        public void CreateNote(string content)
        {
            page.SkipTutorial();
            page.AddNote();
            page.CreateTextNote();
            page.WriteNoteContent(content);
            page.ClickBackButton();
            page.ClickBackButton();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test_CreateNote()
        {
            page.SkipTutorial();
            page.AddNote();
            page.CreateTextNote();
            page.WriteNoteContent("Test_1");
            page.ClickBackButton();
            page.ClickBackButton();

            var note = page.NoteTitle("Test_1");
            Assert.That(note.Text, Is.EqualTo("Test_1"));
        }

        [Test]
        public void Test_EditNote()
        {
            CreateNote("Test_2");

            page.NoteTitle("Test_2").Click();
            page.ClickEditNote();
            page.WriteNoteContent("Edited");
            page.ClickBackButton();
            page.ClickBackButton();

            var editedNote = page.NoteTitle("Edited");

            Assert.That(editedNote.Text, Is.EqualTo("Edited"));
        }

        [Test]
        public void Test_DeleteNote()
        {
            CreateNote("Test_3");

            page.NoteTitle("Test_3").Click();
            page.OpenMenu();
            page.ClickDeleteOption();
            page.ConfirmDelete();

            var deletedNote = page.DeletedNoteTitle("Test_3");

            Assert.That(deletedNote, Is.Empty);
        }
    }
}
