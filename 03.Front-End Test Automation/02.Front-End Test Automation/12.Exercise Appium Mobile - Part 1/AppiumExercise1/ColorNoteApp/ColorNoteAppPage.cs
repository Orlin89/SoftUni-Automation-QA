using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteApp
{
    public class ColorNoteAppPage
    {
        private AndroidDriver driver;

        public ColorNoteAppPage(AndroidDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SkipTutorialButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));

        public IWebElement AddNoteButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));

        public IWebElement CreateTextNoteOption => driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));

        public IWebElement WriteNoteField => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));

        public IWebElement BackButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));

        public IWebElement NoteTitle(string title) => driver.FindElement(MobileBy.XPath($"//android.widget.TextView[@resource-id='com.socialnmobile.dictapps.notepad.color.note:id/title' and @text='{title}']"));

        public IReadOnlyCollection <IWebElement> DeletedNoteTitle(string title) => driver.FindElements(MobileBy.XPath($"//android.widget.TextView[@resource-id='com.socialnmobile.dictapps.notepad.color.note:id/title' and @text='{title}']"));

        public IWebElement EditButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn"));

        public IWebElement MenuButton => driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn"));

        public IWebElement DeleteOption => driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/text\" and @text=\"Delete\"]"));

        public IWebElement ConfirmDeleteButton => driver.FindElement(MobileBy.Id("android:id/button1"));

        public void SkipTutorial()
        {
            try
            {
                SkipTutorialButton.Click();
            }
            catch (NoSuchElementException)
            {
                // Tutorial skip button not found, continue with setup
            }
        }

        public void AddNote() => AddNoteButton.Click();

        public void CreateTextNote() => CreateTextNoteOption.Click();

        public void WriteNoteContent(string content)
        {
            WriteNoteField.Clear();
            WriteNoteField.SendKeys(content);
        }
        
        public void ClickBackButton() => BackButton.Click();

        public void ClickEditNote() => EditButton.Click();  

        public void OpenMenu() => MenuButton.Click();

        public void ClickDeleteOption() => DeleteOption.Click();

        public void ConfirmDelete() => ConfirmDeleteButton.Click();     
    }
}
