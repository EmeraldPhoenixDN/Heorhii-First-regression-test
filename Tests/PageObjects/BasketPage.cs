using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class BasketPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement Checkout_Btn => _driver.FindElement(By.Id("checkout"));
        public IWebElement BasketItemPrice => _driver.FindElement(By.XPath("//div[@class='inventory_item_price'and text()='9.99']"));
        public IWebElement BasketItemName => _driver.FindElement(By.XPath("//div[@class='inventory_item_name'and text()='Sauce Labs Bike Light']"));
        public IWebElement BasketItemQuantity => _driver.FindElement(By.XPath("//div[@class='cart_quantity']"));

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