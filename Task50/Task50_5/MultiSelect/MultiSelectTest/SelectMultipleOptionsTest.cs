using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using MultiSelect;

namespace MultiSelectTest
{
    [TestClass]
    public class SelectMultipleOptionsTest
    {
        const int _expectedSelectedOptionQty = 3;

        [TestMethod]
        public void SelectMultipleOptionsPositive()
        {
            IWebDriver driver = new ChromeDriver(".");

            /* Set driver window position and size, if you need. */
            //driver.Manage().Window.Position = new Point(-1280, 100);
            //driver.Manage().Window.Maximize();

            BasicSelectDropdownDemoPage page = BasicSelectDropdownDemoPage.GoToBasicSelectDropdownDemoPage(driver);

            var selectObject = page.GetSelectElement(page.SELECT_MENU);
            var totalOptionQty = selectObject.Options.Count;
            var indexes = IndexRandomizer.GetRandomIndexes(totalOptionQty, _expectedSelectedOptionQty);

            foreach (int i in indexes)
                selectObject.SelectByIndex(i);

            Assert.AreEqual(_expectedSelectedOptionQty, selectObject.AllSelectedOptions.Count,
                    "Multiple selected option qty doesn't match.");

            driver.Quit();
        }
    }
}
