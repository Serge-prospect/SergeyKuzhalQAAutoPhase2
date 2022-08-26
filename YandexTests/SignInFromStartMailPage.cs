using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Yandex;
using System.Threading;
using System.Collections.Generic;
using System;

namespace YandexTests
{
    [TestClass]
    public class SignInFromStartMailPage
    {
        readonly ConfigData _config;

        public SignInFromStartMailPage()
        {
            _config = new ConfigData();
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLoginData), DynamicDataSourceType.Method)]
        
        public void SignInFromStartMailPagePositive(string username, string password)
        {
            IWebDriver driver = _config.Driver;            

            /* Set driver window position and size, if you need. */
            _config.SetDriverWindow();

            // Go to Start Mail page
            StartMailPage startMailPage = StartMailPage.GoToStartMailPage(_config);

            // Go to Username form to get to Mail page
            PassportUsernamePage passportUsernamePage = startMailPage.GoToPassportUsernamePage();            

            // Enter username
            PassportPasswordPage passportPasswordPage = passportUsernamePage.EnterUsername(username);

            // Enter password and sign in
            MailPage mailPage = passportPasswordPage.EnterPassword(password);

            // Verify that user signed in to their account
            Assert.AreEqual(username, mailPage.GetElementBy(mailPage.ACCOUNT_NAME).GetAttribute("textContent"), "Account name doesn't match.");

            // Sign out and complete test
            mailPage.SignOut();
            driver.Quit();
        }

        public static IEnumerable<object[]> GetLoginData()
        {
            var config = new ConfigData();

            yield return new object[] { config.Users["user1"].Username, config.Users["user1"].Password };
            yield return new object[] { config.Users["user2"].Username, config.Users["user2"].Password };
        }
    }
}
