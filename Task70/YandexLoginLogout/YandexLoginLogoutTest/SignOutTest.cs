using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexLoginLogout;

namespace YandexLoginLogoutTest
{
    [TestClass]
    public class SignOutTest
    {
        const string UnauthMainPageStartPng = "SignOutTestUnauthMainPageStart.png";
        const string UnauthMainPageFinalPng = "SignOutTestUnauthMainPageFinal.png";
        const string AuthMainPagePng = "SignOutTestAuthMainPage.png";

        [TestMethod]
        public void SignOutTestPositive()
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
                config.CreateDirectory(config.ScreenshotPath);
                mainPage.GetPageScreenshotPng
                    ($@"{config.ScreenshotPath}\{UnauthMainPageStartPng}", mainPage.SIGN_IN_BUTTON);
                PassportUsernamePage passportUsernamePage = mainPage.GoToPassportUsernamePage();
                PassportPasswordPage passportPasswordPage = passportUsernamePage.EnterUsername(user.Username);
                MainPage authorizedMainPage = passportPasswordPage.EnterPassword(user.Password);
                authorizedMainPage.GetPageScreenshotPng
                    ($@"{config.ScreenshotPath}\{AuthMainPagePng}", authorizedMainPage.USER_MENU);
                MainPage unAuthorizedMainPage = authorizedMainPage.SignOut();
                mainPage.GetPageScreenshotPng
                    ($@"{config.ScreenshotPath}\{UnauthMainPageFinalPng}", mainPage.SIGN_IN_BUTTON);

                var signInButton = unAuthorizedMainPage.GetWebElementBy(unAuthorizedMainPage.SIGN_IN_BUTTON);
                var loginCookie = unAuthorizedMainPage.GetCookieValue(unAuthorizedMainPage.LoginCookie);
                var sessionCookie = unAuthorizedMainPage.GetCookieValue(unAuthorizedMainPage.SessionCookie);

                Assert.IsTrue(signInButton?.Displayed, "\"Sign In\" button is not displayed.");
                Assert.AreEqual("", loginCookie, "Login cookie is not empty.");
                Assert.IsNull(sessionCookie, "Session_id cookie is present.");
            }
            finally { driver.Quit(); }
        }
    }
}
