using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class MainPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement AddToCart_Btn => _driver.FindElement(By.XPath("(//div[@class='inventory_item_description']/div[@class='pricebar']/button)[2]"));
        public IWebElement ItemPrice => _driver.FindElement(By.XPath("//div[@class='inventory_item_price'and text()='9.99']"));
        public IWebElement Checkout_Btn => _driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement ShoppingCart_Bdg => _driver.FindElement(By.ClassName("shopping_cart_badge"));
        public IWebElement FooterText => _driver.FindElement(By.ClassName("footer_copy"));
        public IWebElement DropDownFilter => _driver.FindElement(By.ClassName("product_sort_container"));
        public IWebElement MurgerMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement About_Lnk => _driver.FindElement(By.Id("about_sidebar_link"));
        public IWebElement Developers => _driver.FindElement(By.XPath("//span[text()='Developers']"));
        public IWebElement Documentation => _driver.FindElement(By.XPath("//span[text()='Documentation']"));



        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAddToCartBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => AddToCart_Btn, 10);
            AddToCart_Btn.Click();
        }

        public void ClickCheckoutBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => Checkout_Btn, 10);
            Checkout_Btn.Click();
        }

    }
}