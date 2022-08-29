using OpenQA.Selenium;

namespace YandexLoginLogout
{
    public class PassportUsernamePage : BasePage
    {
        readonly By LOGIN_BUTTON = By.XPath("//button[@data-type='login']");
        readonly By USERNAME_BUTTON = By.Id("passp-field-login");
        readonly By SIGN_IN_BUTTON = By.Id("passp:sign-in");

        public PassportUsernamePage(IWebDriver driver, int waitTime) : base(driver, waitTime)
        { }

        public PassportPasswordPage EnterUsername(string username)
        {
            GetWebElementBy(LOGIN_BUTTON)?.Click();
            GetWebElementBy(USERNAME_BUTTON)?.SendKeys(username);
            GetWebElementBy(SIGN_IN_BUTTON)?.Click();
            return new PassportPasswordPage(_driver, _waitTime);         
        }
    }
}
