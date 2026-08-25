using System;
using System.Collections.Generic;
using System.Text;







//mini app 
namespace Mini_app
{
    public class Employee
    {
       
            public string No { get; private set; }    // iscinin nomresi   
            public string Fullname { get; set; }
            public string Position { get; set; }          
            public decimal Salary { get; set; }           
            public string DepartmentName { get; set; }

            public Employee(string no, string fullname, string position, decimal salary, string departmentName)
            {
                No = no;
                Fullname = fullname;
                Position = position;
                Salary = salary;
                DepartmentName = departmentName;
           
        }
    }
}
