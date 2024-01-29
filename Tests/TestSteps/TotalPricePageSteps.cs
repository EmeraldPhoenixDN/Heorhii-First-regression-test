using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Tests.PageObjects;

namespace Tests.TestSteps
{
    internal class TotalPricePageSteps
    {
        ScenarioContext _scenarioContext;
        RegressionTests _regressionTests;
        MainPage _mainPage;
        TotalPricePage _totalPricePage;




        public TotalPricePageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _totalPricePage = new TotalPricePage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [Then(@"the total cost should be correct")]
        public void ThenTheTotalCostShouldBeCorrect()
        {
            var itemsfinalPrice = _totalPricePage.ItemPrice.Text;

            var itemsTotalPrice = _regressionTests.NumberSeachInText(_totalPricePage.TotalPrice.Text);
            //Convert to Double
            double itemsTotalPriceValue = Convert.ToDouble(itemsTotalPrice);

            var tax = _regressionTests.NumberSeachInText(_totalPricePage.TaxValue.Text);
            double taxValue = Convert.ToDouble(tax);

            double originalItemPrice = itemsTotalPriceValue - taxValue;
            //Round to needed double format (e.g., 9.99)
            double roundedOriginalItemPrice = Math.Round(originalItemPrice, 2);
            //Convert to string to compare the value with original price
            string stringRoundedOriginalItemPrice = Convert.ToString(roundedOriginalItemPrice);
            ClassicAssert.AreEqual(_mainPage.ItemPrice, stringRoundedOriginalItemPrice);
        }

        [Then(@"the purchase should be successful")]
        public void ThenThePurchaseShouldBeSuccessful()
        {
            _totalPricePage.Finish_Btn.Click();
        }


    }
}

