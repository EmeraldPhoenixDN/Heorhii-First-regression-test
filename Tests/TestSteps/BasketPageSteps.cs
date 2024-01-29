using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;

namespace Tests.TestSteps
{
    [Binding]
    internal class BasketPageSteps
    {
        ScenarioContext _scenarioContext;
        BasketPage _basketPage;
        private readonly IWebDriver _driver;

        RegressionTests regressionTests = new RegressionTests();

        public BasketPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _basketPage = new BasketPage(_scenarioContext.Get<IWebDriver>("WebDriver"));

        }

        [Then(@"the item details should be correct in the cart")]
        public void ThenTheItemDetailsShouldBeCorrectInTheCart()
        {
            var basketItemPrice = regressionTests.NumberSeachInText(_basketPage.BasketItemPrice.Text);
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
