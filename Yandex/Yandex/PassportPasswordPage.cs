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
        const string PasswordInputId = "passp-field-passwd";
        const string SignInButtonId = "passp:sign-in";

        public PassportPasswordPage(IWebDriver driver) : base(driver)
        { }

        public MailPage EnterPassword(string password)
        {
            GetElementById(PasswordInputId)?.SendKeys(password);
            GetElementById(SignInButtonId)?.Click();
            Thread.Sleep(MailPageWaitTime);

            return new MailPage(_driver);
        }
    }
}