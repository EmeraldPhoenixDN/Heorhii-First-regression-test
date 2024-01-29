using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;

namespace Tests.TestSteps
{
    [Binding]
    internal class MainPageSteps
    {
       ScenarioContext _scenarioContext;
        MainPage _mainPage;
        RegressionTests regressionTests = new RegressionTests();


        public MainPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
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

            var itemsCount = _mainPage.ShoppingCart_Bdg.Text;
            var itemsPriceOriginal = regressionTests.NumberSeachInText(_mainPage.ItemPrice.Text);
            var itemsName = _mainPage.ItemName.Text;

            ClassicAssert.AreEqual("1", itemsCount);

            _mainPage.Checkout_Btn.Click();
        }
    }
}
