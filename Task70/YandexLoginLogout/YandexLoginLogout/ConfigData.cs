using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace YandexLoginLogout
{
    public class ConfigData
    {        
        public readonly int WaitTime = 3;
        public readonly Dictionary<string, User> Users;
        public readonly string ScreenshotPath;

        public readonly IWebDriver Driver = new ChromeDriver(".");
        readonly Point _windowPosition = new Point(-1280, 100);

        public ConfigData()
        {
            Users = new Dictionary<string, User>()
            {
                ["user1"] = new User("user220814-1", "Yandex1qaz!QAZ"),
                ["user2"] = new User("user220814-2", "Yandex1qaz!QAZ")
            };
                        
            var solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var screenShotSubPath = @"Task80\SeleniumScreenshots";
            ScreenshotPath = $@"{solutionPath}\{screenShotSubPath}";
        }

        public void SetDriverWindow()
        {
            Driver.Manage().Window.Position = _windowPosition;
            Driver.Manage().Window.Maximize();
        }

        public void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
