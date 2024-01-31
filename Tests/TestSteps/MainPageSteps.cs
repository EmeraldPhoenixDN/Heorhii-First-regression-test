using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class MainPageSteps : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;
        private readonly MainPage _mainPage;

        public string itemsCount;
        public string itemsPriceOriginal;
        public string itemsName;

        public MainPageSteps(ScenarioContext context, WebDriverManager driverManager)
        {
            _scenarioContext = context;
            _driverManager = driverManager;

            // Ensure the WebDriver is initialized only once per scenario
            if (!_scenarioContext.ContainsKey("WebDriver"))
            {
                var chromeDriver = _driverManager.ChromeDriver;
                _scenarioContext.Add("WebDriver", chromeDriver);
            }
            _mainPage = new MainPage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [When(@"the user adds a bag to the cart")]
        public void WhenTheUserAddsABagToTheCart()
        {
            _mainPage.AddToCart_Btn.Click();
        }

        [Then(@"the item should be added to the cart")]
        public void ThenTheItemShouldBeAddedToTheCart()
        {

            itemsCount = _mainPage.ShoppingCart_Bdg.Text;
            itemsPriceOriginal = NumberSeachInText(_mainPage.ItemPrice.Text);
            itemsName = _mainPage.ItemName.Text;

            _scenarioContext.Add("itemsCount", itemsCount);
            _scenarioContext.Add("itemsPriceOriginal", itemsPriceOriginal);
            _scenarioContext.Add("itemsName", itemsName);

            Assert.AreEqual("1", itemsCount);
            _mainPage.Checkout_Btn.Click();
        }
    }
}
