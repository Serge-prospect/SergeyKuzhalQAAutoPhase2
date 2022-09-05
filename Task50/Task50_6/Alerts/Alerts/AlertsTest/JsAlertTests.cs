using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using Alerts;

namespace AlertsTest
{
    [TestClass]
    public class JsAlertTests
    {
        const string EXPECTED_ALERT_BOX_TEXT = "I am an alert box!";
        const string EXPECTED_CONFIRM_ALERT_BOX_TEXT = "Press a button!";
        const string EXPECTED_CONFIRM_DEMO_ACCEPT_TEXT = "You pressed OK!";
        const string EXPECTED_CONFIRM_DEMO_DISMISS_TEXT = "You pressed Cancel!";
        static readonly Point WindowPosition = new Point(-1280, 100);

        [TestMethod]
        public void ClickJsAlertBoxPositive()
        {
            IWebDriver driver = new ChromeDriver(".");

            /* Set driver window position and size, if you need. */
            //SetWindowPosition(driver);

            JavascriptAlertBoxDemoPage page = JavascriptAlertBoxDemoPage.GoToJavascriptAlertBoxDemoPage(driver);
            WebDriverWait wait = page.GetWait();

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(page.JsAlertBoxClickButton))?.Click();

                IAlert Alert = page.GetAlert(wait);
                string jsAlertBoxText = Alert.Text;

                Alert.Accept();

                Assert.AreEqual(EXPECTED_ALERT_BOX_TEXT, jsAlertBoxText, "Alert box text doesn't match.");
            }
            finally { driver.Quit(); }
        }

        [TestMethod]
        public void ClickAcceptJsConfirmAlertBoxPositive()
        {
            IWebDriver driver = new ChromeDriver(".");

            /* Set driver window position and size, if you need. */
            //SetWindowPosition(driver);

            JavascriptAlertBoxDemoPage page = JavascriptAlertBoxDemoPage.GoToJavascriptAlertBoxDemoPage(driver);
            WebDriverWait wait = page.GetWait();

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(page.JsConfirmAlertBoxClickButton))?.Click();

                IAlert Alert = page.GetAlert(wait);
                string jsConfirmAlertBoxText = Alert.Text;

                Alert.Accept();

                string confirmDemoAcceptText = driver.FindElement(page.ConfirmDemoText).Text;

                Assert.AreEqual(EXPECTED_CONFIRM_ALERT_BOX_TEXT, jsConfirmAlertBoxText, "Confirm alert box text doesn't match.");
                Assert.AreEqual(EXPECTED_CONFIRM_DEMO_ACCEPT_TEXT, confirmDemoAcceptText, "Accept confirm demo text doesn't match.");
            }
            finally { driver.Quit(); }            
        }

        [TestMethod]
        public void ClickDismissJsConfirmAlertBoxPositive()
        {
            IWebDriver driver = new ChromeDriver(".");

            /* Set driver window position and size, if you need. */
            //SetWindowPosition(driver);

            JavascriptAlertBoxDemoPage page = JavascriptAlertBoxDemoPage.GoToJavascriptAlertBoxDemoPage(driver);
            WebDriverWait wait = page.GetWait();

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(page.JsConfirmAlertBoxClickButton))?.Click();

                IAlert Alert = page.GetAlert(wait);
                string jsConfirmAlertBoxText = Alert.Text;

                Alert.Dismiss();

                string confirmDemoDismissText = driver.FindElement(page.ConfirmDemoText).Text;

                Assert.AreEqual(EXPECTED_CONFIRM_ALERT_BOX_TEXT, jsConfirmAlertBoxText, "Confirm alert box text doesn't match.");
                Assert.AreEqual(EXPECTED_CONFIRM_DEMO_DISMISS_TEXT, confirmDemoDismissText, "Dismiss confirm demo text doesn't match.");
            }
            finally { driver.Quit(); }
        }

        static void SetWindowPosition(IWebDriver driver)
        {
            driver.Manage().Window.Position = WindowPosition;
            driver.Manage().Window.Maximize();
        }
    }
}
