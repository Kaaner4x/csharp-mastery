using LINQ.Models;

namespace LINQ.Services;

public class CompanyDatabase
{
    public List<Department> Departments { get; }
    public List<Employee> Employees { get; }

    public CompanyDatabase()
    {
        Departments = new List<Department>
        {
            new Department { Id = 1, Name = "IT", City = "Istanbul" },
            new Department { Id = 2, Name = "HR", City = "Ankara" },
            new Department { Id = 3, Name = "Finance", City = "Istanbul" }
        };

        Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ali Yilmaz", DepartmentId = 1, Salary = 45000, Skills = new List<string> { "C#", "SQL" } },
            new Employee { Id = 2, Name = "Ayse Kaya", DepartmentId = 1, Salary = 55000, Skills = new List<string> { "C#", "Azure", "React" } },
            new Employee { Id = 3, Name = "Veli Demir", DepartmentId = 2, Salary = 35000, Skills = new List<string> { "Recruitment", "Communication" } },
            new Employee { Id = 4, Name = "Zeynep Celik", DepartmentId = 3, Salary = 48000, Skills = new List<string> { "Accounting", "Excel" } },
            new Employee { Id = 5, Name = "Can Oz", DepartmentId = 1, Salary = 38000, Skills = new List<string> { "Python", "Docker" } }
        };
    }
}
