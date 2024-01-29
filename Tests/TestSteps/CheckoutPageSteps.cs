using ICSharpCode.SharpZipLib.GZip;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tests.PageObjects;

namespace Tests.TestSteps
{
    internal class CheckoutPageSteps
    {
        ScenarioContext _scenarioContext;
        CheckoutPage _checkoutPage;
        

        const string FirstName = "Heorhii";
        const string LastName = "Sashniev";
        const string Zip = "051997";



        public CheckoutPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _checkoutPage = new CheckoutPage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [When(@"puts in user  information")]
        public void WhenPutsInUserInformation()
        {
            _checkoutPage.FirstName_Field.SendKeys(FirstName);
            _checkoutPage.LastName_Field.SendKeys(LastName);
            _checkoutPage.Zip_Field.SendKeys(Zip); 
        }

        [When(@"completes the checkout process")]
        public void WhenCompletesTheCheckoutProcess() { 
            _checkoutPage.Continue_Btn.Click();
        }
    }
}
