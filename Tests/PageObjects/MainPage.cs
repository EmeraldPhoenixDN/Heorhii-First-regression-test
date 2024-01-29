using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class MainPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement AddToCart_Btn => _driver.FindElement(By.XPath("(//div[@class='inventory_item_description']/div[@class='pricebar']/button)[2]"));
        public IWebElement ItemPrice => _driver.FindElement(By.XPath("//div[@class='inventory_item_price'and text()='9.99']"));
        public IWebElement ItemName => _driver.FindElement(By.XPath("//div[@class='inventory_item_name ' and text()='Sauce Labs Bike Light']"));
        public IWebElement Checkout_Btn => _driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement ShoppingCart_Bdg => _driver.FindElement(By.ClassName("shopping_cart_badge"));

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAddToCartBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => AddToCart_Btn, 10);
            AddToCart_Btn.Click();
        }

        public CheckoutPage ClickCheckoutBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => Checkout_Btn, 10);
            Checkout_Btn.Click();
            return new CheckoutPage(_driver);
        }
    }
}