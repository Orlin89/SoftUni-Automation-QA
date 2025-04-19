using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Interactions;


namespace ZoomGestures
{
    [TestFixture]
    public class ZoomTests
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            _appiumLocalService.Start();

            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UIAutomator2",
                DeviceName = "Pixel9",
                App = @"D:\ApiDemos-debug.apk"
            };

            _driver = new AndroidDriver(_appiumLocalService.ServiceUrl, androidOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private void ScrollToText(string text)
        {
            _driver.FindElement(MobileBy.AndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"" + text + "\"))"));
        }

        [Test]
        public void ZoomInTest()
        {
            var views = _driver.FindElement(MobileBy.AccessibilityId("Views"));
            views.Click();

            ScrollToText("WebView");

            var webViewOption = _driver.FindElement(MobileBy.AccessibilityId("WebView"));
            webViewOption.Click();

            // Perform zoom in action with the given coordinates
            PerformZoomIn(112, 655, 123, 370, 105, 785, 90, 1058);
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

            _driver.PerformActions(new List<ActionSequence> { zoomIn1, zoomIn2 });
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

            _driver.PerformActions(new List<ActionSequence> { zoomOut1, zoomOut2 });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver?.Dispose();
            _appiumLocalService.Dispose();
        }
    }
}
