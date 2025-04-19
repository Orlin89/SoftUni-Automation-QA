using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Pages
{
    public class HiddenMenuPage : BasePage
    {
        public HiddenMenuPage(IWebDriver driver) : base(driver) { }

        private readonly By MenuButton = By.CssSelector(".bm-burger-button");
        private readonly By LogoutButton = By.Id("logout_sidebar_link");
        private readonly By MenuContainer = By.ClassName("bm-menu-wrap");

        public void ClickMenuButton()
        {
            Click(MenuButton);
        }

        public void ClickLogoutButton() 
        {
            Click(LogoutButton);
        }

        public bool IsMenuOpen()
        {
            return FindElement(LogoutButton).Displayed;
        }
    }
}
