using CSharp.Mastery.InheritanceAndPolymorphism.Models;
using CSharp.Mastery.InheritanceAndPolymorphism.Services;

namespace CSharp.Mastery.InheritanceAndPolymorphism;

class Program
{
    static void Main()
    {
        var manager = new Manager(1, "Ahmet Yılmaz", 50000m, 15000m, 5);
        var dev1 = new Developer(2, "Ayşe Kaya", 40000m, "C#", 3);
        var dev2 = new Developer(3, "Mehmet Demir", 38000m, "TypeScript", 2);

        // A list of the base class can hold derived instances
        var employees = new List<Employee> { manager, dev1, dev2 };

        var payrollService = new PayrollService();
        payrollService.ProcessPayroll(employees);
    }
}
