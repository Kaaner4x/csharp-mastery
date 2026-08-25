namespace LINQ.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
    public List<string> Skills { get; set; } = new();
    
    public override string ToString()
    {
        return $"[{Id}] {Name} - Dept: {DepartmentId} - Salary: {Salary:C}";
    }
}
