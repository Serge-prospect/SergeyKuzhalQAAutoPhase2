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

        Dictionary<string, IWebElement> _elementCollection;

        public MailPage(IWebDriver driver) : base(driver)
        {
            var inBoxButton = GetElementByXpath(InboxButtonXPath);
            var profileButton = GetElementByClassName(ProfileButtonClassName);
            var signOutButton = GetElementByClassName(SignOutButtonClassName);

            _elementCollection = new Dictionary<string, IWebElement>()
            {               
                ["inbox"] = inBoxButton,
                ["profile"] = profileButton,
                ["signOut"] = signOutButton
            };                      
        }

        public void SignOut()
        {
            _elementCollection["profile"]?.Click();
            _elementCollection["signOut"]?.Click();

            _driver.Close();
        }
    }
}