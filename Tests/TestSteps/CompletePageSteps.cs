using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Tests.PageObjects;

namespace Tests.TestSteps
{
    [Binding]
    internal class CompletePageSteps
    {
        ScenarioContext _scenarioContext;
        CompletePage _completePage;

        public CompletePageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _completePage = new CompletePage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [Then(@"main page is opened")]
        public void ThenMainPageIsOpened()
        {
            _completePage.BackHome_Btn.Click();
        }
    }
}


