using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_app
{
    public interface HumanSearchINapp
    {
        List<Department> Departments { get; set; }
        void AddDepartment(string name, int workerLimit, decimal salaryLimit);
        List<Department> GetDepartments();
        void EditDepartment(string currentName, string newName);
        void AddEmployee(string fullname, string position, decimal salary, string departmentName);
        void RemoveEmployee(string employeeNo, string departmentName);
        void EditEmployee(string employeeNo, decimal salary, string position);
        List<Employee> Search(string keyword);
    }
}

