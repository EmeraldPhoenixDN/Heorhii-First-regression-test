using OpenQA.Selenium;
using WebDrv;

namespace Tests.PageObjects
{
    public class TotalPricePage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement Finish_Btn => _driver.FindElement(By.Id("finish"));
        public IWebElement ItemPrice => _driver.FindElement(By.XPath("//div[@class='summary_subtotal_label'and text()='9.99']"));
        public IWebElement TotalPrice => _driver.FindElement(By.XPath("//div[@class='summary_info_label summary_total_label']"));
        public IWebElement TaxValue => _driver.FindElement(By.XPath("//div[@class='summary_tax_label'and text()='0.80']"));





        public TotalPricePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FinishBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => Finish_Btn, 10);
            Finish_Btn.Click();
        }
    }
}