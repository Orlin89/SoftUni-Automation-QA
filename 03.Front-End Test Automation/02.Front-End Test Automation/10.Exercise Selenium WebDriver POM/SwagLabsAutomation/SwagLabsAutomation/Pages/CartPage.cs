using OpenQA.Selenium;


namespace SwagLabsAutomation.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        private readonly By itemsInCart = By.XPath("//div[@class='cart_item']");

        private readonly By checkoutButton = By.Id("checkout");

        public bool IsCartItemDisplayed()
        {
            return FindElement(itemsInCart).Displayed;
        }

        public void ClickCheckout()
        {
            Click(checkoutButton);
        }
    }
}
