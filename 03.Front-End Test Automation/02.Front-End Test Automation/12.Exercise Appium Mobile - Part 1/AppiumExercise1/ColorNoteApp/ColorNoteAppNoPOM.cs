
using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumTColorNoteApp;

[TestFixture]
public class TeColorNoteAppNoPOM
{
    private AndroidDriver _driver;

    [OneTimeSetUp]
    public void SetUp()
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

        _driver = new AndroidDriver(new Uri("http://127.0.0.1:4723"), androidOptions);

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        try
        {
            var skipTutorial = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));
            skipTutorial.Click();

            var allowButton = _driver.FindElement(MobileBy.Id("com.android.permissioncontroller:id/permission_allow_button"));
            allowButton.Click();
        }
        catch (NoSuchElementException)
        {
            //Tutorial skip button not found, continue with setup 
        }
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    public void Test_CreateNote()
    {
      
        var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
        addNote.Click();

        var textOption = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
        textOption.Click();

        var writeField = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
        writeField.SendKeys("Test_1");

        var backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        backButton.Click();

        backButton.Click();

        var note = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

        Assert.That(note, Is.Not.Null);
        Assert.That(note.Text, Is.EqualTo("Test_1"));
    }

    [Test]
    public void Test_EditNote()
    {
        // Create note
        var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
        addNote.Click();

        var textOption = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
        textOption.Click();

        var writeField = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
        writeField.SendKeys("Test_2");

        var backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        backButton.Click();

        backButton.Click();

        var note = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

        // Edit note
        note.Click();

        var editButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn"));
        editButton.Click();

        writeField = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
        writeField.Clear();
        writeField.SendKeys("Edited");

        backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        backButton.Click();
        backButton.Click();

        Assert.That(note, Is.Not.Null);
        Assert.That(note.Text, Is.EqualTo("Edited"));
    }

    [Test]
    public void Test_DeleteNote()
    {
        // Create note
        var addNote = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1"));
        addNote.Click();

        var textOption = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")"));
        textOption.Click();

        var writeField = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note"));
        writeField.SendKeys("Test_3");

        var backButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn"));
        backButton.Click();

        // Delete note
        var menuButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn"));
        menuButton.Click();

        var deleteButton = _driver.FindElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.socialnmobile.dictapps.notepad.color.note:id/text\" and @text=\"Delete\"]"));
        deleteButton.Click();

        var confirmButton = _driver.FindElement(MobileBy.Id("android:id/button1"));
        confirmButton.Click();

        var note = _driver.FindElements(MobileBy.XPath("//android.widget.TextView[@text='Test_3']"));
        Assert.That(note, Is.Empty);
    }
}
