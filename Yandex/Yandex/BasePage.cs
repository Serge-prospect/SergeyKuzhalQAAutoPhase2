using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Yandex
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        public const int ElementWaitTime = 250;
        public const int MailPageWaitTime = ElementWaitTime * 20;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetElementByXpath(string xPath)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.XPath(xPath));
        }

        public IWebElement GetElementByCssSelector(string cssSelector)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement GetElementByClassName(string className)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.ClassName(className));
        }

        public IWebElement GetElementByTagName(string tagName)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.TagName(tagName));
        }

        public IWebElement GetElementByName(string name)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.Name(name));
        }

        public IWebElement GetElementByLinkText(string linkText)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.LinkText(linkText));
        }

        public IWebElement GetElementByPartialLinkText(string partialLinkText)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.PartialLinkText(partialLinkText));
        }        

        public IWebElement GetElementById(string id)
        {
            Thread.Sleep(ElementWaitTime);
            return _driver.FindElement(By.Id(id));
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
