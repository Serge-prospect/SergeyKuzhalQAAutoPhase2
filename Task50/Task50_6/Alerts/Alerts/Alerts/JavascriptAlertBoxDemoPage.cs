using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace Alerts
{
    public class JavascriptAlertBoxDemoPage
    {
        const int WAIT_TIME = 10;
        const string URL = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        public readonly By JsAlertBoxClickButton = By.CssSelector("button[onclick='myAlertFunction()']");
        public readonly By JsConfirmAlertBoxClickButton = By.CssSelector("button[onclick='myConfirmFunction()']");
        public readonly By ConfirmDemoText = By.CssSelector("#confirm-demo");
        readonly IWebDriver _driver;

        public JavascriptAlertBoxDemoPage(IWebDriver driver) => _driver = driver;

        public static JavascriptAlertBoxDemoPage GoToJavascriptAlertBoxDemoPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(URL);
            return new JavascriptAlertBoxDemoPage(driver);
        }

        public WebDriverWait GetWait() => new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME));

        public IAlert GetAlert(WebDriverWait wait) => wait.Until(ExpectedConditions.AlertIsPresent());
    }
}
