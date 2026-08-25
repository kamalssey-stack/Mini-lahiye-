using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_app
{
public class Department
    {
            public string Name { get; set; }           
            public int WorkerLimit { get; set; }         
            public decimal SalaryLimit { get; set; }    
            public List<Employee> Employees { get; set; } = new List<Employee>();

            private int Counter = 0; 

            public Department (string name, int workerLimit, decimal salaryLimit)
            {
                Name = name;
                WorkerLimit = workerLimit;
                SalaryLimit = salaryLimit;
            }

            public decimal CalcSalaryAverage()
            {
                if (Employees.Count == 0) return 0;
                decimal total = 0;
                foreach (var emp in Employees)
                    total += emp.Salary;
                return total / Employees.Count;
            }

           
            public string GenerateEmployeeNo()
            {
                Counter++;
                string prefix = Name.Substring(0, 2).ToUpper();
                return prefix + (1000 + Counter - 1).ToString();
            }
        }
    }

