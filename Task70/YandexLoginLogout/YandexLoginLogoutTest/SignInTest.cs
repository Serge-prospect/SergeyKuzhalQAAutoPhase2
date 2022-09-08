using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using YandexLoginLogout;

namespace YandexLoginLogoutTest
{
    [TestClass]
    public class SignInTest
    {
        const string UnauthMainPage = "SignInTestUnauthMainPage.png";
        const string AuthMainPage = "SignInTestAuthMainPage.png";

        [TestMethod]
        public void SignInTestPositive()
        {
            var config = new ConfigData();
            var user = config.Users["user1"];
            var driver = config.Driver;

            /* Set window position */
            //config.SetDriverWindow();
            driver.Manage().Window.Maximize();
            
            try
            {
                MainPage mainPage = MainPage.GoToMainPage(config);
                mainPage.GetPageScreenshotPng
                    (config.ScreenshotPath + UnauthMainPage, mainPage.SIGN_IN_BUTTON);
                PassportUsernamePage passportUsernamePage = mainPage.GoToPassportUsernamePage();
                PassportPasswordPage passportPasswordPage = passportUsernamePage.EnterUsername(user.Username);
                MainPage authorizedMainPage = passportPasswordPage.EnterPassword(user.Password);
                authorizedMainPage.GetPageScreenshotPng
                    (config.ScreenshotPath + AuthMainPage, authorizedMainPage.USER_MENU);

                var accountUsername = authorizedMainPage.GetAccountUsername();
                var loginCookie = authorizedMainPage.GetCookieValue(authorizedMainPage.LoginCookie);
                var sessionCookie = authorizedMainPage.GetCookieValue(authorizedMainPage.SessionCookie);

                Assert.AreEqual(user.Username, accountUsername, "Account username doesn't match.");
                Assert.AreEqual(user.Username, loginCookie, "Login cookie doesn't contain username.");
                Assert.IsNotNull(sessionCookie, "No Session_id cookie.");
            }
            finally { driver.Quit(); }
        }
    }
}
