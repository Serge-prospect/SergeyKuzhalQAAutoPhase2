using System;
using System.Collections.Generic;
using System.Text;

namespace FilteredEmployeeList
{
    public class Employee
    {
        public string Name { get; }
        public string Position { get; }
        public string Office { get; }

        public Employee(string name, string position, string office)
        {
            Name = name;
            Position = position;
            Office = office;
        }
    }
}
