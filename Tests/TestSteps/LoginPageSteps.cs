using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class LoginPageSteps
    {

        ScenarioContext _scenarioContext;
        private readonly WebDriverManager _driverManager;

        public LoginPageSteps(ScenarioContext context, WebDriverManager driverManager) {
            _scenarioContext = context;
            _driverManager = driverManager;

        }

        [Given(@"login to the site with username '([^']*)' and password '([^']*)'")]
        public void GivenLoginToTheSiteWithUsernameAndPassword(string userName, string password)
        {
            var chromeDriver = _driverManager.ChromeDriver;
            chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(chromeDriver);
            loginPage.Login(userName, password);

            _scenarioContext.Add("WebDriver", chromeDriver);
        }
}
}

