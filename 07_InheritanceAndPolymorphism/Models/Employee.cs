namespace CSharp.Mastery.InheritanceAndPolymorphism.Models;

public abstract class Employee
{
    public int Id { get; }
    public string Name { get; }
    public decimal BaseSalary { get; }

    // Constructor chaining base
    protected Employee(int id, string name, decimal baseSalary)
    {
        Id = id;
        Name = name;
        BaseSalary = baseSalary;
    }

    // Abstract method must be overridden in derived classes
    public abstract decimal CalculateTotalSalary();

    // Virtual method provides default behavior, can be overridden
    public virtual string GetEmployeeDetails()
    {
        return $"[{Id}] {Name} - Base Salary: {BaseSalary:C}";
    }
}
