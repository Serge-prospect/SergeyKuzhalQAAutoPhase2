using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Yandex;
using System.Threading;

namespace YandexTests
{
    [TestClass]
    public class SignIn
    {
        readonly ConfigData _config;

        public SignIn()
        {
            _config = new ConfigData();
        }

        [TestMethod]
        public void SignInPositive()
        {
            var user = "user1";

            IWebDriver driver = _config.Driver;
            
            /* Set driver window position and size, if you need. */
            //_config.SetDriverWindow();

            // Go to Start page
            StartPage startPage = StartPage.GoToStartPage(_config);

            // Go to Username form to get to Mail page
            PassportUsernamePage passportUsernamePage = startPage.GoToPassportUsernamePage();            

            // Enter username
            PassportPasswordPage passportPasswortPage = passportUsernamePage.EnterUsername(_config.Users[user].Username);

            // Enter password and sign in
            MailPage mailPage = passportPasswortPage.EnterPassword(_config.Users[user].Password);
            
            // Verify that user is signed in
            Assert.IsTrue(mailPage.GetElementByXpath(MailPage.InboxButtonXPath).Displayed, "Element Inbox button is not displayed.");

            // Sign out and complete test
            mailPage.SignOut();
            driver.Quit();
        }
    }
}
