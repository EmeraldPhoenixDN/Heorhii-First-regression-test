using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class CompletePage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement BackHome_Btn => _driver.FindElement(By.XPath("//div[@class='checkout_complete_container']/button"));
        public CompletePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void BackHomeBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => BackHome_Btn, 10);
            BackHome_Btn.Click();
        }
    }
}