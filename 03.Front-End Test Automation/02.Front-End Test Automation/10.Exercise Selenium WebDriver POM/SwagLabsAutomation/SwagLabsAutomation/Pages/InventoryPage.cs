using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver) { }

        private readonly By cartLinkElement = By.XPath("//a[@class='shopping_cart_link']");

        private readonly By productsTitle = By.XPath("//span[@class='title']");

        private readonly By inventoryItems = By.XPath("//div[@class='inventory_item']");

        public void AddToCartByIndex(int index)
        {
            By itemAddToCartButton = By.XPath($"(//div[@class='inventory_item'])[{index}]//button");
            Click(itemAddToCartButton);
        }

        public void AddToCartByName(string name)
        {
            By itemAddToCart = By.XPath($"//div[text()='{name}']/ancestor::div[@class='inventory_item']//button");
            Click(itemAddToCart);
        }

        public void ClickCartLink()
        {
            Click(cartLinkElement);
        }

        public bool IsINventoryDisplayed()
        {
            return FindElements(inventoryItems).Any();
        }

        public bool IsPageLoaded()
        {
            return GetText(productsTitle) == "Products" && driver.Url.Contains("inventory.html");
        }
    }

   

    
}
