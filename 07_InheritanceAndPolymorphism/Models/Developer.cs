namespace CSharp.Mastery.InheritanceAndPolymorphism.Models;

public class Developer : Employee
{
    public string ProgrammingLanguage { get; }
    public int ProjectCount { get; }

    public Developer(int id, string name, decimal baseSalary, string programmingLanguage, int projectCount) 
        : base(id, name, baseSalary)
    {
        ProgrammingLanguage = programmingLanguage;
        ProjectCount = projectCount;
    }

    public override decimal CalculateTotalSalary()
    {
        // 500 bonus per project
        return BaseSalary + (ProjectCount * 500m);
    }

    public override string GetEmployeeDetails()
    {
        return $"{base.GetEmployeeDetails()} | Role: Developer ({ProgrammingLanguage}), Projects: {ProjectCount}";
    }
}
