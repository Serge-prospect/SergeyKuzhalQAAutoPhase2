using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace YandexLoginLogout
{
    public abstract class BasePage
    {
        public readonly string LoginCookie = "yandex_login";
        public readonly string SessionCookie = "Session_id";
        protected IWebDriver _driver;
        protected int _waitTime;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver driver, int waitTime)
        {
            _driver = driver;
            _waitTime = waitTime;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
        }

        public IWebElement GetWebElementBy(By elementLocator)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch
            {
                return null;
            }
        }

        public string GetCookieValue(string cookieName)
        {
            try
            {
                return _driver.Manage().Cookies.GetCookieNamed(cookieName)?.Value;
            }
            catch
            {
                return null;
            }
        }
    }
}
