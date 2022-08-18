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
        public const string InboxButtonXPath = "//a[@href='#tabs/relevant']";
        const string ProfileButtonClassName = "user-account";
        const string SignOutButtonClassName = "legouser__menu-item_action_exit";

        public MailPage(IWebDriver driver) : base(driver)
        { }

        public void SignOut()
        {
            GetElementByClassName(ProfileButtonClassName)?.Click();
            GetElementByClassName(SignOutButtonClassName)?.Click();

            _driver.Close();
        }
    }
}