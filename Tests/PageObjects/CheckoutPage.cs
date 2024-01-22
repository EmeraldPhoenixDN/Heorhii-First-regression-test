using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class CheckoutPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement FirstName_Field => _driver.FindElement(By.Id("first-name"));
        public IWebElement LastName_Field => _driver.FindElement(By.Id("last-name"));
        public IWebElement Zip_Field => _driver.FindElement(By.Id("postal-code"));
        public IWebElement Continue_Btn => _driver.FindElement(By.Id("continue"));

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public CheckoutPage CheckoutForm(string firstName, string lastName, string zip)
        {
            FirstName_Field.SendKeys(firstName);
            LastName_Field.SendKeys(lastName);
            Zip_Field.SendKeys(zip);
            Continue_Btn.Click();

            return new CheckoutPage(_driver);
        }
    }
}