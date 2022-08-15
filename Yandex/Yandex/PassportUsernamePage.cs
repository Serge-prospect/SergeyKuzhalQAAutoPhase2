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

        Dictionary<string, IWebElement> _elementCollection;

        public PassportUsernamePage(IWebDriver driver) : base(driver)
        {
            var loginButton = GetElementByXpath(LoginButtonXPath);
            var usernameInput = GetElementById(UsernameInputId);
            var signInButton = GetElementById(SignInButtonId);

            _elementCollection = new Dictionary<string, IWebElement>()
            {
                ["login"] = loginButton,
                ["username"] = usernameInput,
                ["signIn"] = signInButton
            };
        }

        public PassportPasswordPage EnterUsername(string username)
        {
            _elementCollection["login"]?.Click();
            _elementCollection["username"]?.SendKeys(username);
            _elementCollection["signIn"]?.Click();
            Thread.Sleep(ElementWaitTime);

            return new PassportPasswordPage(_driver);
        }
    }
}