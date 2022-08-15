using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Yandex
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigData();
            
            IWebDriver driver = config.Driver;

            /* Set driver window position and size, if you need. */
            config.SetDriverWindow();

            StartPage startPage = StartPage.GoToStartPage(config);
            PassportUsernamePage passportUsernamePage = startPage.GoToPassportUsernamePage();                        
            PassportPasswordPage passportPasswortPage = passportUsernamePage.EnterUsername(config.Users["user1"].Username);
            MailPage mailPage = passportPasswortPage.EnterPassword(config.Users["user1"].Password);

            mailPage.SignOut();
            driver.Quit();
        }
    }
}
