using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WaitForUser
{
    class Program
    {
        static readonly int _waitTime = 30;
        static readonly string[] _newUserStatus = new string[2] { "New user is not displayed.", "New user is displayed." };

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(".");
            DynamicDataLoadingDemo page = DynamicDataLoadingDemo.GoToDynamicDataLoadingDemoPage(driver, _waitTime);

            try
            {
                page.GetElement(page.GetNewUserButton)?.Click();

                bool isNewUserDisplayed = page.IsNewUserDisplayed();
                PrintNewUserStatus(isNewUserDisplayed);
            }
            finally { driver.Quit(); }
        }

        static void PrintNewUserStatus(bool isNewUserDisplayed)
        {
            if (isNewUserDisplayed)
                Console.WriteLine(_newUserStatus[1]);
            else
                Console.WriteLine(_newUserStatus[0]);
        }
    }
}
