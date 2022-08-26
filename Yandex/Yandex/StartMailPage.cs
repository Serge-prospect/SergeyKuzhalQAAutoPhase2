using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public class StartMailPage : BasePage
    {
        readonly By LOGIN_BUTTON = By.ClassName("PSHeader-NoLoginButton");
        
        public StartMailPage(IWebDriver driver) : base(driver)
        { }

        public static StartMailPage GoToStartMailPage(ConfigData config)
        {            
            config.Driver.Url = config.StartUrls["startMailPageUrl"];
            config.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTime);

            return new StartMailPage(config.Driver);
        }

        public PassportUsernamePage GoToPassportUsernamePage()
        {
            var originalWindow = GetOriginalWindow();

            GetElementByClassName(LOGIN_BUTTON)?.Click();
            Thread.Sleep(SleepTime);

            SwitchToNewWindow(originalWindow);

            return new PassportUsernamePage(_driver);
        }
    }
}