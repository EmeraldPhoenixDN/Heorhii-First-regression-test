using NUnit.Framework.Legacy;
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
        RegressionTests regressionTests = new RegressionTests();
        MainPage _mainPage;

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

            ClassicAssert.AreEqual(_mainPage.ItemPrice, basketItemPrice);
            ClassicAssert.AreEqual(_mainPage.ItemName, basketItemName);
            ClassicAssert.AreEqual("1", itemsQuantity);
        }

        [When(@"the user goes to checkout")]
        public void WhenTheUserGoesToCheckout()
        {
            _basketPage.Checkout_Btn.Click();
        }
    }
}
