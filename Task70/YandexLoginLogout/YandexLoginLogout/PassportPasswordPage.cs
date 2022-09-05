using OpenQA.Selenium;

namespace YandexLoginLogout
{
    public class PassportPasswordPage : BasePage
    {
        readonly By PASSWORD_INPUT = By.Id("passp-field-passwd");
        readonly By SIGN_IN_BUTTON = By.Id("passp:sign-in");

        public PassportPasswordPage(IWebDriver driver, int waitTime) : base(driver, waitTime)
        { }

        public MainPage EnterPassword(string password)
        {
            GetWebElementBy(PASSWORD_INPUT)?.SendKeys(password);
            GetWebElementBy(SIGN_IN_BUTTON)?.Click();
            return new MainPage(_driver, _waitTime);
        }
    }
}
