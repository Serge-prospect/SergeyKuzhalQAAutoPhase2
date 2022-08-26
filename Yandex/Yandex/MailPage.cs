using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public class MailPage : BasePage
    {
        public readonly By INBOX_BUTTON = By.XPath("//a[@href='#tabs/relevant']");
        public readonly By ACCOUNT_NAME = By.CssSelector("a.legouser__current-account span.user-account__name");
        readonly By PROFILE_BUTTON = By.ClassName("legouser__current-account");
        readonly By SIGN_OUT_BUTTON = By.ClassName("legouser__menu-item_action_exit");

        public MailPage(IWebDriver driver) : base(driver)
        { }

        public void SignOut()
        {
            GetElementByClassName(PROFILE_BUTTON)?.Click();
            GetElementByClassName(SIGN_OUT_BUTTON)?.Click();

            _driver.Close();
        }
    }
}