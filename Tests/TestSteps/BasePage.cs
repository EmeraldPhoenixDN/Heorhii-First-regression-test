using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Tests.TestSteps
{
    abstract public class BasePage
    {
        public string NumberSeachInText(string RecivedString)
        {
            string SentString = Regex.Match(RecivedString, @"\d+\.\d+").Value;
            return SentString;
        }
    }
}