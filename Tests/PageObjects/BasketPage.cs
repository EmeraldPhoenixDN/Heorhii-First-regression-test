using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class BasketPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement Checkout_Btn => _driver.FindElement(By.Id("checkout"));
        public IWebElement ItemPrice => _driver.FindElement(By.XPath("//div[@class='inventory_item_price'and text()='9.99']"));




        public BasketPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CheckoutBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => Checkout_Btn, 10);
            Checkout_Btn.Click();
        }
    }
}