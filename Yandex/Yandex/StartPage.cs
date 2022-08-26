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
        readonly By LOGIN_BUTTON = By.ClassName("desk-notif-card__login-new-item_mail");
        
        public StartPage(IWebDriver driver) : base(driver)
        { }

        public static StartPage GoToStartPage(ConfigData config)
        {
            config.Driver.Url = config.StartUrls["startPageUrl"];
            Thread.Sleep(SleepTime);

            return new StartPage(config.Driver);
        }

        public PassportUsernamePage GoToPassportUsernamePage()
        {
            var originalWindow = GetOriginalWindow();

            GetElementByClassName(LOGIN_BUTTON)?.Click();
            Thread.Sleep(PageSleepTime);

            SwitchToNewWindow(originalWindow);

            return new PassportUsernamePage(_driver);
        }
    }
}