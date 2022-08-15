using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public class StartPage : BasePage
    {
        const string LoginButtonClassName = "desk-notif-card__login-new-item_mail";

        Dictionary<string, IWebElement> _elementCollection;

        public StartPage(IWebDriver driver) : base(driver)
        {
            var loginButton = GetElementByClassName(LoginButtonClassName);

            _elementCollection = new Dictionary<string, IWebElement>()
            {
                ["login"] = loginButton
            };
        }

        public static StartPage GoToStartPage(ConfigData config)
        {
            config.Driver.Url = config.StartPageUrl;
            Thread.Sleep(ElementWaitTime);

            return new StartPage(config.Driver);
        }

        public PassportUsernamePage GoToPassportUsernamePage()
        {
            var originalWindow = GetOriginalWindow();

            _elementCollection["login"]?.Click();
            Thread.Sleep(ElementWaitTime);

            SwitchToNewWindow(originalWindow);

            return new PassportUsernamePage(_driver);
        }
    }
}