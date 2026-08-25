using CSharp.Mastery.InheritanceAndPolymorphism.Models;

namespace CSharp.Mastery.InheritanceAndPolymorphism.Services;

public class PayrollService
{
    // Accepts any Employee type (Polymorphism in action)
    public void ProcessPayroll(IEnumerable<Employee> employees)
    {
        Console.WriteLine("=== Processing Payroll ===");
        decimal totalPayroll = 0;

        foreach (var employee in employees)
        {
            // Dynamic binding at runtime determines which CalculateTotalSalary runs
            decimal salary = employee.CalculateTotalSalary();
            totalPayroll += salary;
            
            Console.WriteLine(employee.GetEmployeeDetails());
            Console.WriteLine($"-> Payout: {salary:C}\n");
        }

        Console.WriteLine($"Total Company Payroll: {totalPayroll:C}");
    }
}
