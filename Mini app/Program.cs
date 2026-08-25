using System;
using Mini_app;

HumanSearchINapp hr = new HumanSearchINapp2();

hr.AddDepartment("Maliyye", 10, 5000);
hr.AddEmployee("Ali Mammadov", "Muhasib", 800, "Maliyye");

var emp = hr.Search("Ali")[0];
Console.WriteLine($"isci: {emp.Fullname}, nomresi: {emp.No}, otdel: {emp.DepartmentName}");