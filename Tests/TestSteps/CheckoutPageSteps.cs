using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class CheckoutPageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;
        private readonly CheckoutPage _checkoutPage;

        const string FirstName = "Heorhii";
        const string LastName = "Sashniev";
        const string Zip = "051997";

        public CheckoutPageSteps(ScenarioContext context, WebDriverManager driverManager)
        {
            _scenarioContext = context;
            _driverManager = driverManager;

            // Ensure the WebDriver is initialized only once per scenario
            if (!_scenarioContext.ContainsKey("WebDriver"))
            {
                var chromeDriver = _driverManager.ChromeDriver;
                _scenarioContext.Add("WebDriver", chromeDriver);
            }
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
