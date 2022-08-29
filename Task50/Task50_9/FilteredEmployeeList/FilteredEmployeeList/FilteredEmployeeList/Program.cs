using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FilteredEmployeeList
{
    class Program
    {
        const string selectEntriesQty = "10";
        const int minAge = 40;
        const int maxSalary = 200000;        
        const int waitTime = 2;        

        static void Main(string[] args)
        {            
            var driver = new ChromeDriver(".");

            var page = TableSortSearchDemoPage.GoToTableSortSearchDemoPage(driver, waitTime);
            var selectMenu = new SelectElement(page.GetWebElementBy(page.SelectShowEntries));
            selectMenu.SelectByValue(selectEntriesQty);

            var employees = page.GetFilteredEmployeeList(minAge, maxSalary);

            DisplayEmployees(employees);
            
            driver.Quit();
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            Console.WriteLine($"Total filtered employees quantity: {employees.Count}");

            foreach (Employee e in employees)
            {
                Console.WriteLine(string.Join("\t", e.Name, e.Position, e.Office));
            }            
        }
    }    
}
