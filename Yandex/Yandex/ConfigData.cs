using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace Yandex
{
    public class ConfigData
    {
        public readonly Dictionary<string, string> StartUrls;

        public readonly Dictionary<string, User> Users;
    
        public readonly IWebDriver Driver = new ChromeDriver(".");
        public readonly Point WindowPosition = new Point(-1280, 100);

        public ConfigData()
        {
            StartUrls = new Dictionary<string, string>()
            {
                ["startPageUrl"] = "https:\\yandex.com",
                ["startMailPageUrl"] = "https:\\mail.yandex.com"
            };

            Users = new Dictionary<string, User>()
            {
                ["user1"] = new User("user220814-1", "Yandex1qaz!QAZ"),
                ["user2"] = new User("user220814-2", "Yandex1qaz!QAZ")
            };           
        }

        public void SetDriverWindow()
        {
            Driver.Manage().Window.Position = WindowPosition;
            Driver.Manage().Window.Maximize();
        }
    }
}
