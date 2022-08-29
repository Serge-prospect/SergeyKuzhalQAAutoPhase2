using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FilteredEmployeeList
{
    public class TableSortSearchDemoPage
    {        
        public const string URL = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
        public readonly int NameColumn = 1;
        public readonly int PositionColumn = 2;
        public readonly int OfficeColumn = 3;
        public readonly int AgeColumn = 4;
        public readonly int StartDateColumn = 5;
        public readonly int SalaryColumn = 6;
        public readonly By SelectShowEntries = By.XPath("//select[@name='example_length']");
        public readonly By DisplayedEntries = By.XPath("//tbody/tr");
        public readonly By previousButtonDisabled = By.XPath("//a[contains(@class,'previous')]");
        public readonly By nextButtonEnabled = By.XPath("//a[contains(@class,'next')]");
        public readonly By nextButtonDisabled = By.XPath("//a[contains(@class,'next') and contains(@class,'disabled')]");
        IWebDriver _driver;
        WebDriverWait _wait;

        public TableSortSearchDemoPage(IWebDriver driver, int waitTime)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
        }

        public static TableSortSearchDemoPage GoToTableSortSearchDemoPage(IWebDriver driver, int waitTime)
        {
            driver.Navigate().GoToUrl(URL);
            return new TableSortSearchDemoPage(driver, waitTime);
        }

        public IWebElement GetWebElementBy(By elementLocator)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool IsFirstPage()
        {
            return GetWebElementBy(previousButtonDisabled).Displayed;
        }

        public bool IsLastPage()
        {
            try
            {
                return GetWebElementBy(nextButtonDisabled).Displayed;
            }
            catch { return false; }
        }

        public List<Employee> GetFilteredEmployeeList(int minAge, int maxSalary)
        {
            var employees = new List<Employee>();

            if (IsFirstPage())
            {
                var isLastPage = false;
                while (!isLastPage)
                {
                    var displayedEntriesQty = _driver.FindElements(DisplayedEntries).Count;

                    for (int i = 1; i <= displayedEntriesQty; i++)
                    {
                        var ageLocator = By.XPath($"//tbody/tr[{i}]/td[{AgeColumn}]");
                        var salaryLocator = By.XPath($"//tbody/tr[{i}]/td[{SalaryColumn}]");

                        var age = int.Parse(GetWebElementBy(ageLocator).Text);
                        var salary = int.Parse(GetWebElementBy(salaryLocator).GetAttribute("data-order"));

                        if (age > minAge && salary <= maxSalary)
                        {
                            var nameLocator = By.XPath($"//tbody/tr[{i}]/td[{NameColumn}]");
                            var positionLocator = By.XPath($"//tbody/tr[{i}]/td[{PositionColumn}]");
                            var officeLocator = By.XPath($"//tbody/tr[{i}]/td[{OfficeColumn}]");

                            var name = GetWebElementBy(nameLocator).GetAttribute("data-search");
                            var position = GetWebElementBy(positionLocator).Text;
                            var office = GetWebElementBy(officeLocator).Text;

                            employees.Add(new Employee(name, position, office));
                        }
                    }
                    if (IsLastPage())
                        isLastPage = IsLastPage();
                    else
                        GetWebElementBy(nextButtonEnabled).Click();
                }
            }
            return employees;
        }
    }
}
