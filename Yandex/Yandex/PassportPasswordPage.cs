using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public class PassportPasswordPage : BasePage
    {        
        readonly By PASSWORD_INPUT = By.Id("passp-field-passwd");
        readonly By SIGN_IN_BUTTON = By.Id("passp:sign-in");

        public PassportPasswordPage(IWebDriver driver) : base(driver)
        { }

        public MailPage EnterPassword(string password)
        {
            GetElementById(PASSWORD_INPUT)?.SendKeys(password);
            GetElementById(SIGN_IN_BUTTON)?.Click();
            Thread.Sleep(PageSleepTime);

            return new MailPage(_driver);
        }
    }
}