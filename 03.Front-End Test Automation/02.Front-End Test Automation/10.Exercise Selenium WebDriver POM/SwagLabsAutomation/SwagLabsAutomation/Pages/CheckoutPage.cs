using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        private readonly By FirstNameInput = By.Id("first-name");
        private readonly By LastNameInput = By.Id("last-name");
        private readonly By PostalCode = By.Id("postal-code");
        private readonly By ContinueButton = By.Id("continue");
        private readonly By FinishButton = By.Id("finish");
        private readonly By CompletionHeader = By.TagName("h2");

        public void EnterFirstName(string firstName)
        {
            Type(FirstNameInput, firstName);
        }

        public void EnterLastName(string lastName)
        {
            Type(LastNameInput, lastName);
        }

        public void EnterPostalCode(string postalCode)
        {
            Type(PostalCode, postalCode);
        }

        public void ClickContinue()
        {
            Click(ContinueButton);
        }

        public void ClickFinish()
        {
            Click(FinishButton);
        }

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("checkout-step-one.html") ||
                driver.Url.Contains("checkout-step-two.html");
        }

        public bool IsCheckoutComplete()
        {
            return GetText(CompletionHeader) == "Thank you for your order!";
        }
    }
}
