using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class CompletePageSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;
        private readonly CompletePage _completePage;

        public CompletePageSteps(ScenarioContext context, WebDriverManager driverManager)
        {
            _scenarioContext = context;
            _driverManager = driverManager;

            // Ensure the WebDriver is initialized only once per scenario
            if (!_scenarioContext.ContainsKey("WebDriver"))
            {
                var chromeDriver = _driverManager.ChromeDriver;
                _scenarioContext.Add("WebDriver", chromeDriver);
            }
            _completePage = new CompletePage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [Then(@"main page is opened")]
        public void ThenMainPageIsOpened()
        {
            _completePage.BackHome_Btn.Click();
        }
    }
}


