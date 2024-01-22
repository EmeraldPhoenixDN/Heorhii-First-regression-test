using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebDrv
{
    public class WebDriverUtils
    {
        ITakesScreenshot _takeScreenshot;

        public WebDriverUtils(IWebDriver driver)
        {
            _takeScreenshot = (ChromeDriver)driver;
        }

        public void TakeScreenshot()
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            _takeScreenshot.GetScreenshot().SaveAsFile($"C:\\QALightTrainings\\Screenshots\\Test-{screenshotName}.png");
        }
    }
}