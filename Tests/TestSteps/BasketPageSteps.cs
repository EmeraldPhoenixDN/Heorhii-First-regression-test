using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class BasketPageSteps : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;
        private readonly BasketPage _basketPage;

        public BasketPageSteps(ScenarioContext context, WebDriverManager driverManager)
        {
            _scenarioContext = context;
            _driverManager = driverManager;

            // Ensure the WebDriver is initialized only once per scenario
            if (!_scenarioContext.ContainsKey("WebDriver"))
            {
                var chromeDriver = _driverManager.ChromeDriver;
                _scenarioContext.Add("WebDriver", chromeDriver);
            }
            _basketPage = new BasketPage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [Then(@"the item details should be correct in the cart")]
        public void ThenTheItemDetailsShouldBeCorrectInTheCart()
        {
            var basketItemPrice = NumberSeachInText(_basketPage.BasketItemPrice.Text);
            var basketItemName = _basketPage.BasketItemName.Text;
            var itemsQuantity = _basketPage.BasketItemQuantity.Text;
            var originalItemPrice = _scenarioContext.Get<string>("itemsPriceOriginal");
            var originalItemName = _scenarioContext.Get<string>("itemsName");

            Assert.AreEqual(originalItemPrice, basketItemPrice);
            Assert.AreEqual(originalItemName, basketItemName);
            Assert.AreEqual("1", itemsQuantity);
        }

        [When(@"the user goes to checkout")]
        public void WhenTheUserGoesToCheckout()
        {
            _basketPage.Checkout_Btn.Click();
        }
    }
}
