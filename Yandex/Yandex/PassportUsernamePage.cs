using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public class PassportUsernamePage : BasePage
    {
        const string LoginButtonXPath = "//button[@data-type='login']";
        const string UsernameInputId = "passp-field-login";
        const string SignInButtonId = "passp:sign-in";

        public PassportUsernamePage(IWebDriver driver) : base(driver)
        { }

        public PassportPasswordPage EnterUsername(string username)
        {
            var loginButton = GetElementByXpath(LoginButtonXPath);
            var usernameInput = GetElementById(UsernameInputId);
            var signInButton = GetElementById(SignInButtonId);

            GetElementByXpath(LoginButtonXPath)?.Click();
            GetElementById(UsernameInputId)?.SendKeys(username);
            GetElementById(SignInButtonId)?.Click();
            Thread.Sleep(ElementWaitTime);

            return new PassportPasswordPage(_driver);
        }
    }
}