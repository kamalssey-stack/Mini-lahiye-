using System;
using System.Collections.Generic;

namespace Mini_app
{
    public class HumanSearchINapp2 : HumanSearchINapp
    {
        public List<Department> Departments { get; set; } = new List<Department>();

        public void AddDepartment(string name, int workerLimit, decimal salaryLimit)
        {
            if (name.Length < 2)
                throw new Exception("Название департамента должно быть не менее 2 символов.");
            if (workerLimit < 1)
                throw new Exception("Лимит сотрудников должен быть не менее 1.");
            if (salaryLimit < 250)
                throw new Exception("Лимит зарплаты должен быть не менее 250.");

            Departments.Add(new Department(name, workerLimit, salaryLimit));
        }

        public List<Department> GetDepartments()
        {
            return Departments;
        }

        public void EditDepartment(string currentName, string newName)
        {
            Department dept = Departments.Find(d => d.Name.Equals(currentName, StringComparison.OrdinalIgnoreCase));
            if (dept != null)
            {
                dept.Name = newName;
            }
        }

        public void AddEmployee(string fullname, string position, decimal salary, string departmentName)
        {
            Department dept = Departments.Find(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (dept == null)
                throw new Exception("Департамент не найден.");

            if (dept.Employees.Count >= dept.WorkerLimit)
                throw new Exception("Лимит сотрудников в департаменте превышен.");

           
            decimal totalSalary = salary;
            foreach (var emp in dept.Employees)
                totalSalary += emp.Salary;

            if (totalSalary > dept.SalaryLimit)
                throw new Exception("Лимит общей зарплаты департамента будет превышен.");

            if (position.Length < 2)
                throw new Exception("Должность должна быть не менее 2 символов.");
            if (salary < 250)
                throw new Exception("Зарплата не может быть менее 250.");

            string employeeNo = dept.GenerateEmployeeNo();
            Employee newEmp = new Employee(employeeNo, fullname, position, salary, departmentName);
            dept.Employees.Add(newEmp);
        }

        public void RemoveEmployee(string employeeNo, string departmentName)
        {
            Department dept = Departments.Find(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (dept != null)
            {
                Employee emp = dept.Employees.Find(e => e.No.Equals(employeeNo, StringComparison.OrdinalIgnoreCase));
                if (emp != null)
                {
                    dept.Employees.Remove(emp);
                }
            }
        }

        public void EditEmployee(string employeeNo, decimal salary, string position)
        {
            if (position.Length < 2)
                throw new Exception("Должность должна быть не менее 2 символов.");
            if (salary < 250)
                throw new Exception("Зарплата не может быть менее 250.");

            foreach (var dept in Departments)
            {
                Employee emp = dept.Employees.Find(e => e.No.Equals(employeeNo, StringComparison.OrdinalIgnoreCase));
                if (emp != null)
                {
                    emp.Salary = salary;
                    emp.Position = position;
                    return;
                }
            }
        }

        public List<Employee> Search(string keyword)
        {
            List<Employee> foundEmployees = new List<Employee>();
            foreach (var dept in Departments)
            {
                foreach (var emp in dept.Employees)
                {
                    if (emp.Fullname.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        emp.No.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        emp.Position.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        emp.DepartmentName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        foundEmployees.Add(emp);
                    }
                }
            }
            return foundEmployees;
        }
    }
}