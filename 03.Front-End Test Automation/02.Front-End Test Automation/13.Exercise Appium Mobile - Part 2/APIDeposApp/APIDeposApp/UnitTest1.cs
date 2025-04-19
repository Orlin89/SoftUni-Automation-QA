using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using OpenQA.Selenium.BiDi.Modules.Input;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace APIDeposApp
{
    public class Tests
    {
        private AndroidDriver driver;

        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions
            {
               PlatformName = "Android",
               AutomationName = "UiAutomator2",
               DeviceName = "AppiumDemoDevice",
               App = "B:\\Front-End Test Automation\\13.Exercise Appium Mobile - Part 2\\AppForTesting\\ApiDemos-debug.apk"
            };

            driver = new AndroidDriver(appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void ScrollTest()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            var listsElement = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Lists\"))"));
            listsElement.Click();

            var firstElementInLIsts = driver.FindElement(MobileBy.AccessibilityId("01. Array"));
            Assert.That(firstElementInLIsts, Is.Not.Null);
        }

        [Test]
        public void SwipeTest() 
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();
            driver.FindElement(MobileBy.AccessibilityId("Gallery")).Click();
            driver.FindElement(MobileBy.AccessibilityId("1. Photos")).Click();

            var pic1 = driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[0];

            var action = new Actions(driver);
            var swipe = action.ClickAndHold(pic1)
                .MoveByOffset(-200, 0)
                .Release()
                .Build();
            swipe.Perform();

            var pic3 = driver.FindElements(MobileBy.ClassName("android.widget.ImageView"))[2];
            Assert.That(pic3, Is.Not.Null);
        }

        [Test]
        public void DragAndDrop()
        {
            driver.FindElement(MobileBy.AccessibilityId("Views")).Click();
            driver.FindElement(MobileBy.AccessibilityId("Drag and Drop")).Click();

            var drag = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_1"));
            var drop = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_dot_2"));

            var scriptsArgs = new Dictionary<string, object>
            {
                { "elementId", drag.Id },
                { "endX", drop.Location.X + (drop.Size.Width / 2) },
                { "endY", drop.Location.Y + (drop.Size.Height / 2) },
                { "speed", 2500 }
            };

            driver.ExecuteScript("mobile: dragGesture", scriptsArgs);

            var dropSuccessMessage = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/drag_result_text"));
            Assert.That(dropSuccessMessage.Text, Is.EqualTo("Dropped!"));
        }

        [Test]
        public void SeekBarTest() 
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            ScrollToText("Seek Bar");

            var seekBarOption = driver.FindElement(MobileBy.AccessibilityId("Seek Bar"));
            seekBarOption.Click();
    
            MoveSeekBarWithInspectorCoordinates(546, 350, 1248, 350);

            var seekBarValueElement = driver.FindElement(MobileBy.Id("io.appium.android.apis:id/progress"));
            var seekBarValueText = seekBarValueElement.Text;

            Assert.That(seekBarValueText, Is.EqualTo("100 from touch=true"));
        }

        [Test]
        public void ZoomInTest()
        {
            var views = driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            ScrollToText("WebView");

            var webViewOption = driver.FindElement(MobileBy.AccessibilityId("WebView"));
            webViewOption.Click();

            // Perform zoom in action with the given coordinates
            PerformZoomIn(112, 655, 123, 370, 105, 785, 90, 1058);
        }

        [Test]
        public void ZoomOutTest()
        {
            // Perform zoom out action with the given coordinates
            PerformZoomOut(123, 370, 112, 655, 90, 1058, 105, 785);
        }

        private void PerformZoomOut(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomOut1 = new ActionSequence(finger1);
            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1, TimeSpan.Zero));
            zoomOut1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomOut1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1, TimeSpan.FromMilliseconds(1500)));
            zoomOut1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomOut2 = new ActionSequence(finger2);
            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2, TimeSpan.Zero));
            zoomOut2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomOut2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2, TimeSpan.FromMilliseconds(1500)));
            zoomOut2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomOut1, zoomOut2 });
        }


        private void PerformZoomIn(int startX1, int startY1, int endX1, int endY1, int startX2, int startY2, int endX2, int endY2)
        {
            var finger1 = new PointerInputDevice(PointerKind.Touch);
            var finger2 = new PointerInputDevice(PointerKind.Touch);

            var zoomIn1 = new ActionSequence(finger1);
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, startX1, startY1, TimeSpan.Zero));
            zoomIn1.AddAction(finger1.CreatePointerDown(MouseButton.Left));
            zoomIn1.AddAction(finger1.CreatePointerMove(CoordinateOrigin.Viewport, endX1, endY1, TimeSpan.FromMilliseconds(1500)));
            zoomIn1.AddAction(finger1.CreatePointerUp(MouseButton.Left));

            var zoomIn2 = new ActionSequence(finger2);
            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, startX2, startY2, TimeSpan.Zero));
            zoomIn2.AddAction(finger2.CreatePointerDown(MouseButton.Left));
            zoomIn2.AddAction(finger2.CreatePointerMove(CoordinateOrigin.Viewport, endX2, endY2, TimeSpan.FromMilliseconds(1500)));
            zoomIn2.AddAction(finger2.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { zoomIn1, zoomIn2 });
        }


        private void MoveSeekBarWithInspectorCoordinates(int startX, int startY, int endX, int endY)
        {
            var finger = new PointerInputDevice(PointerKind.Touch);
            var start = new Point(startX, startY);
            var end = new Point(endX, endY);
            var swipe = new ActionSequence(finger);
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, start.X, start.Y, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(MouseButton.Left));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, end.X, end.Y, TimeSpan.FromMilliseconds(1000)));
            swipe.AddAction(finger.CreatePointerUp(MouseButton.Left));
            driver.PerformActions(new List<ActionSequence> { swipe });
        }

        private void ScrollToText(string text)
        {
            driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"" + text + "\"))"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}