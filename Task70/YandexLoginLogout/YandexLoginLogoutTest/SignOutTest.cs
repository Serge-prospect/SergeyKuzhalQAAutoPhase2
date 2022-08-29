using Microsoft.VisualStudio.TestTools.UnitTesting;
using YandexLoginLogout;

namespace YandexLoginLogoutTest
{
    [TestClass]
    public class SignOutTest
    {
        [TestMethod]
        public void SignOutTestPositive()
        {
            var config = new ConfigData();
            var user = config.Users["user1"];
            var driver = config.Driver;

            /* Set window position */
            //config.SetDriverWindow();
            
            try
            {
                MainPage mainPage = MainPage.GoToMainPage(config);
                PassportUsernamePage passportUsernamePage = mainPage.GoToPassportUsernamePage();
                PassportPasswordPage passportPasswordPage = passportUsernamePage.EnterUsername(user.Username);
                MainPage authorizedMainPage = passportPasswordPage.EnterPassword(user.Password);
                MainPage unAuthorizedMainPage = authorizedMainPage.SignOut();

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
