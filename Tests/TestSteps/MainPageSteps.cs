using NUnit.Framework;
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

       public string itemsCount;
       public string itemsPriceOriginal;
       public string itemsName;



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

            itemsCount = _mainPage.ShoppingCart_Bdg.Text;
            itemsPriceOriginal = regressionTests.NumberSeachInText(_mainPage.ItemPrice.Text);
            itemsName = _mainPage.ItemName.Text;

            _scenarioContext.Add("itemsCount", itemsCount);
            _scenarioContext.Add("itemsPriceOriginal", itemsPriceOriginal);
            _scenarioContext.Add("itemsName", itemsName);

            Assert.AreEqual("1", itemsCount);

            _mainPage.Checkout_Btn.Click();
        }
    }
}
