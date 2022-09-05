using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WaitForUser
{
    public class DynamicDataLoadingDemo
    {
        const string URL = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
        public readonly By GetNewUserButton = By.Id("save");
        public readonly By newUserPhotoLocator = By.CssSelector("#loading>img[src*='api/portraits'][src*='.jpg']");
        public readonly By newUserFullNameLocator =
                            By.XPath("//div[contains(text()[1],'First Name') and contains(text()[2],'Last Name')]");
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;

        public DynamicDataLoadingDemo(IWebDriver driver, int waitTime)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
        }
        public static DynamicDataLoadingDemo GoToDynamicDataLoadingDemoPage(IWebDriver driver, int waitTime)
        {
            driver.Navigate().GoToUrl(URL);
            return new DynamicDataLoadingDemo(driver, waitTime);
        }

        public IWebElement GetElement(By elementBy)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementExists(elementBy));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool IsNewUserDisplayed()
        {
            try
            {
                return GetElement(newUserPhotoLocator).Displayed
                    && GetElement(newUserFullNameLocator).Displayed;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
