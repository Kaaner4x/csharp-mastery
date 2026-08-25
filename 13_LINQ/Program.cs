using LINQ.Models;
using LINQ.Services;

namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== C# Mastery: 13 - LINQ ===");
        var db = new CompanyDatabase();

        // 1. Where ve Select (Filtreleme ve Projeksiyon)
        Console.WriteLine("\n--- Yüksek Maaşlı IT Çalışanları (Method Syntax) ---");
        var highEarners = db.Employees
            .Where(e => e.DepartmentId == 1 && e.Salary > 40000)
            .Select(e => new { e.Name, e.Salary }) // Anonymous type
            .ToList(); // Deferred execution burada tetiklenir

        foreach (var emp in highEarners)
            Console.WriteLine($"{emp.Name} - {emp.Salary:C}");

        // 2. Join (Departman ve Çalışanları Birleştirme)
        Console.WriteLine("\n--- Çalışan ve Departman Listesi (Query Syntax) ---");
        var employeeWithDepts = from e in db.Employees
                                join d in db.Departments on e.DepartmentId equals d.Id
                                select new { e.Name, DeptName = d.Name, d.City };

        foreach (var item in employeeWithDepts)
            Console.WriteLine($"{item.Name} -> {item.DeptName} ({item.City})");

        // 3. GroupBy (Departmanlara Göre Gruplama)
        Console.WriteLine("\n--- Departmanlara Göre Toplam ve Ortalama Maaşlar ---");
        var deptStats = db.Employees
            .GroupBy(e => e.DepartmentId)
            .Select(g => new 
            {
                DeptId = g.Key,
                TotalSalary = g.Sum(e => e.Salary),
                AvgSalary = g.Average(e => e.Salary),
                EmployeeCount = g.Count()
            });

        foreach (var stat in deptStats)
            Console.WriteLine($"Dept: {stat.DeptId} | Kişi: {stat.EmployeeCount} | Toplam Maaş: {stat.TotalSalary:C} | Ort: {stat.AvgSalary:C}");

        // 4. SelectMany (İç içe listeleri düzleştirme - Flattening)
        // Bütün çalışanların yeteneklerini (Skills) tek bir liste haline getirip eşsiz (Distinct) olanları bulalım.
        Console.WriteLine("\n--- Şirketteki Tüm Eşsiz Yetenekler (SelectMany) ---");
        var allUniqueSkills = db.Employees
            .SelectMany(e => e.Skills)
            .Distinct()
            .OrderBy(skill => skill)
            .ToList();

        Console.WriteLine(string.Join(", ", allUniqueSkills));

        // 5. Aggregate
        Console.WriteLine("\n--- Aggregate ile Özel İşlem ---");
        // Aggregate, dizideki elemanları tek bir sonuca indirgemek için kullanılır.
        // Örnek: Çalışan isimlerini aralarına virgül koyarak birleştirelim. (String.Join ile aynı mantık)
        var allNames = db.Employees.Select(e => e.Name).Aggregate((current, next) => current + " | " + next);
        Console.WriteLine(allNames);
        
        Console.WriteLine("\nİşlemler tamamlandı.");
    }
}
