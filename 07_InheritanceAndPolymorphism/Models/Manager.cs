namespace CSharp.Mastery.InheritanceAndPolymorphism.Models;

// Sealed class prevents further inheritance
public sealed class Manager : Employee
{
    public decimal Bonus { get; }
    public int TeamSize { get; }

    // Constructor chaining using 'base'
    public Manager(int id, string name, decimal baseSalary, decimal bonus, int teamSize) 
        : base(id, name, baseSalary)
    {
        Bonus = bonus;
        TeamSize = teamSize;
    }

    // Overriding abstract method
    public override decimal CalculateTotalSalary()
    {
        return BaseSalary + Bonus + (TeamSize * 100m); // Extra 100 per team member
    }

    // Overriding virtual method
    public override string GetEmployeeDetails()
    {
        return $"{base.GetEmployeeDetails()} | Role: Manager, Bonus: {Bonus:C}, Team Size: {TeamSize}";
    }
}
