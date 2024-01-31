using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Tests.TestSteps
{
    abstract public class BasePage
    {
        public void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click(element).Build().Perform();
        }

        public void SelectValueFromDropDown(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public string NumberSeachInText(string RecivedString)
        {
            string SentString = Regex.Match(RecivedString, @"\d+\.\d+").Value;
            return SentString;
        }
    }
}