using OpenQA.Selenium;

namespace YandexLoginLogout
{
    public class MainPage : BasePage
    {
        const string _url = "https:\\yandex.com";

        public readonly By SIGN_IN_BUTTON = By.CssSelector("a.desk-notif-card__login-new-item_enter");
        public readonly By USER_MENU =
            By.XPath("//span[contains(@class,'username')]//parent::a[contains(@class,'usermenu-link__control')]");
        readonly By SIGN_OUT_BUTTON = By.XPath("//a[contains(@href,'mode=logout')]");
        readonly By ACCOUNT_NAME = By.CssSelector("div.usermenu__user-name");

        public MainPage(IWebDriver driver, int waitTime) : base(driver, waitTime)
        { }

        public static MainPage GoToMainPage(ConfigData config)
        {
            config.Driver.Url = _url;
            return new MainPage(config.Driver, config.WaitTime);
        }

        public PassportUsernamePage GoToPassportUsernamePage()
        {
            GetWebElementBy(SIGN_IN_BUTTON)?.Click();
            return new PassportUsernamePage(_driver, _waitTime);            
        }

        public string GetAccountUsername()
        {
            GetWebElementBy(USER_MENU)?.Click();
            return GetWebElementBy(ACCOUNT_NAME)?.Text;
        }

        public MainPage SignOut()
        {
            GetWebElementBy(USER_MENU)?.Click();
            GetWebElementBy(SIGN_OUT_BUTTON)?.Click();
            return new MainPage(_driver, _waitTime);
        }
    }
}
