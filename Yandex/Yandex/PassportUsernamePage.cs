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
        readonly By LOGIN_BUTTON = By.XPath("//button[@data-type='login']");
        readonly By USERNAME_INPUT = By.Id("passp-field-login");
        readonly By SIGN_IN_BUTTON = By.Id("passp:sign-in");

        public PassportUsernamePage(IWebDriver driver) : base(driver)
        { }

        public PassportPasswordPage EnterUsername(string username)
        {
            GetElementByXpath(LOGIN_BUTTON)?.Click();
            GetElementById(USERNAME_INPUT)?.SendKeys(username);
            GetElementById(SIGN_IN_BUTTON)?.Click();
            Thread.Sleep(SleepTime);

            return new PassportPasswordPage(_driver);
        }
    }
}