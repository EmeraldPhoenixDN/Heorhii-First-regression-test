using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    internal class LoginPageSteps
    {
        ScenarioContext _scenarioContext;
        WebDriverManager _driverManager = new WebDriverManager();

        public LoginPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;

        }

        [Given(@"login to the site with username '([^']*)' and password '([^']*)'")]
        public void GivenLoginToTheSiteWithUsernameAndPassword(string userName, string password)
        {
            _driverManager.ChromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            LoginPage _loginPage = new LoginPage(_driverManager.ChromeDriver);
            _loginPage.Login(userName, password);

            _scenarioContext.Add("WebDriver", _driverManager.ChromeDriver);
        }

        [When(@"the user logs in with valid credentials")]
        public void WhenTheUserLogsInWithValidCredentials()
        {

        }
    }
}
