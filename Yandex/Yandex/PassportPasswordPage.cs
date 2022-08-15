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

        Dictionary<string, IWebElement> _elementCollection;

        public PassportPasswordPage(IWebDriver driver) : base(driver)
        {
            var passwordInput = GetElementById(PasswordInputId);
            var signInButton = GetElementById(SignInButtonId);

            _elementCollection = new Dictionary<string, IWebElement>()
            {               
                ["password"] = passwordInput,
                ["signIn"] = signInButton
            };
        }

        public MailPage EnterPassword(string password)
        {
            _elementCollection["password"]?.SendKeys(password);
            _elementCollection["signIn"]?.Click();
            Thread.Sleep(MailPageWaitTime);

            return new MailPage(_driver);
        }
    }
}