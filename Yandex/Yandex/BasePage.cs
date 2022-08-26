using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Yandex
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        public const int SleepTime = 250;
        public const int PageSleepTime = SleepTime * 20;
        public const int ImplicitWaitTime = 10;
        const int ExplicitWaitTime = 60;
        const int PollingIntervalTime = 2;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetElementBy(By elementLocator)
        {
            var wait = new WebDriverWait(_driver, timeout: TimeSpan.FromSeconds(ExplicitWaitTime))                
            {
                PollingInterval = TimeSpan.FromSeconds(PollingIntervalTime),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            return wait.Until(drv => drv.FindElement(elementLocator));       
        }

        public IWebElement GetElementByXpath(By xPath)
        {
            /* 
             * Tread.Sleep is something between explicit and implicit waits.
             * Because it onnly affects a certain place in the code like an explicit wait.
             * And it has no conditions other than the time to complete waiting like an implicit wait.
             */
            Thread.Sleep(SleepTime);
            return _driver.FindElement(xPath);
        }

        public IWebElement GetElementByCssSelector(By cssSelector)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(cssSelector);
        }

        public IWebElement GetElementByClassName(By className)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(className);
        }

        public IWebElement GetElementByTagName(By tagName)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(tagName);
        }

        public IWebElement GetElementByName(By name)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(name);
        }

        public IWebElement GetElementByLinkText(By linkText)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(linkText);
        }

        public IWebElement GetElementByPartialLinkText(By partialLinkText)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(partialLinkText);
        }        

        public IWebElement GetElementById(By id)
        {
            Thread.Sleep(SleepTime);
            return _driver.FindElement(id);
        }
        
        public string GetOriginalWindow()
        {
            return _driver.CurrentWindowHandle;
        }

        public void SwitchToNewWindow(string originalWindow)
        {
            foreach (string window in _driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    _driver.SwitchTo().Window(window);
                    break;
                }
            }
        }
    }
}
