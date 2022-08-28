using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace RefreshPageAt50
{
    public class BootstrapDownloadProgressDemoPage
    {
        const string URL = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
        public By DownloadButton = By.Id("cricle-btn");
        public By PctProgress = By.CssSelector("#fakhar-cricle .percenttext");
        IWebDriver _driver;
        WebDriverWait _wait;

        public BootstrapDownloadProgressDemoPage(IWebDriver driver, int[] timeOutAndPollTime)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, timeout: TimeSpan.FromSeconds(timeOutAndPollTime[0]))
            {
                PollingInterval = TimeSpan.FromSeconds(timeOutAndPollTime[1])
            };
        }

        public static BootstrapDownloadProgressDemoPage GoToBootstrapDownloadProgressDemoPage(IWebDriver driver, int[] timeOutAndPollTime)
        {
            driver.Navigate().GoToUrl(URL);
            return new BootstrapDownloadProgressDemoPage(driver, timeOutAndPollTime);
        }

        public IWebElement GetelementBy(By elementBy)
        {
            try
            {
                _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return _wait.Until(ExpectedConditions.ElementExists(elementBy));
            }
            catch { return null; }
        }

        public bool IsProgressAchievedPctAmount(int pctAmount)
        {
            try
            {
                return _wait.Until(pct => Convert.ToInt32(GetelementBy(PctProgress)?.Text.TrimEnd('%')) >= pctAmount);                
            }
            catch { return false; }
        }

        public void RefreshPage()
        {
            Console.WriteLine("The page is refreshed.");
            _driver.Navigate().Refresh();
        }
    }
}
