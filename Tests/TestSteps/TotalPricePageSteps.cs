using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class TotalPricePageSteps : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;
        private readonly TotalPricePage _totalPricePage;

        public string itemsCount;
        public string itemsPriceOriginal;
        public string itemsName;

        public TotalPricePageSteps(ScenarioContext context, WebDriverManager driverManager)
        {
            _scenarioContext = context;
            _driverManager = driverManager;

            // Ensure the WebDriver is initialized only once per scenario
            if (!_scenarioContext.ContainsKey("WebDriver"))
            {
                var chromeDriver = _driverManager.ChromeDriver;
                _scenarioContext.Add("WebDriver", chromeDriver);
            }

            _totalPricePage = new TotalPricePage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [When(@"the total cost should be correct")]
        public void WhenTheTotalCostShouldBeCorrect()
        {
            var origialItemPrice = _scenarioContext.Get<string>("itemsPriceOriginal");
            var itemsTotalPrice = _totalPricePage.TotalPrice.Text;
            var roundedItemsTotalPrice = NumberSeachInText(itemsTotalPrice);
            //Convert to Double
            double itemsTotalPriceValue = Convert.ToDouble(roundedItemsTotalPrice);

            var tax = NumberSeachInText(_totalPricePage.TaxValue.Text);
            double taxValue = Convert.ToDouble(tax);

            double originalItemPrice = itemsTotalPriceValue - taxValue;
            //Round to needed double format (e.g., 9.99)
            double roundedOriginalItemPrice = Math.Round(originalItemPrice, 2);
            //Convert to string to compare the value with original price
            string stringRoundedOriginalItemPrice = Convert.ToString(roundedOriginalItemPrice);

            Assert.AreEqual(origialItemPrice, stringRoundedOriginalItemPrice);
        }

        [When(@"the purchase should be successful")]
        public void WhenThePurchaseShouldBeSuccessful()
        {
            _totalPricePage.Finish_Btn.Click();
        }


    }
}

