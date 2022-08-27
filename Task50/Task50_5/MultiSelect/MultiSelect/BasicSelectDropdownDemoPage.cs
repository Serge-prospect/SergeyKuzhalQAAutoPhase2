using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MultiSelect
{
    public class BasicSelectDropdownDemoPage
    {
        public readonly By SELECT_MENU = By.XPath("//select[@id='multi-select']");
        const int WaitTime = 60;
        const int PollingTime = 2;
        const string URL = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";        
        readonly By OPTION = By.TagName("option");
        IWebDriver _driver;

        public BasicSelectDropdownDemoPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static BasicSelectDropdownDemoPage GoToBasicSelectDropdownDemoPage(IWebDriver driver)
        {
            driver.Url = BasicSelectDropdownDemoPage.URL;
            return new BasicSelectDropdownDemoPage(driver);
        }

        public IWebElement GetElementBy(By elementLocator)
        {
            var wait = new WebDriverWait(_driver, timeout: TimeSpan.FromSeconds(WaitTime))
            {
                PollingInterval = TimeSpan.FromSeconds(PollingTime),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            return wait.Until(drv => drv.FindElement(elementLocator));
        }

        public SelectElement GetSelectElement(By selectMenuLocator)
        {
            var selectMenuElement = GetElementBy(selectMenuLocator);           
            return new SelectElement(selectMenuElement);
        }        
                
        public List<string> GetOptionTextList(By selectMenuElement)
        {
            var optionTextList = new List<string>();

            IWebElement selectMenu = GetElementBy(selectMenuElement);
            IList<IWebElement> options = selectMenu.FindElements(OPTION);

            foreach (IWebElement option in options)
            {
                optionTextList.Add(option.GetAttribute("textContent"));
            }

            return optionTextList;
        }
    }
}
