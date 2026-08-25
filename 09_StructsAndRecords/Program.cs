using CSharp.Mastery.StructsAndRecords.Models;

namespace CSharp.Mastery.StructsAndRecords;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Structs and Records ===");

        // 1. readonly struct
        var myLocation = new GpsCoordinate(41.0082, 28.9784); // Istanbul
        var yourLocation = new GpsCoordinate(41.0082, 28.9784);
        
        Console.WriteLine($"Location: {myLocation}");
        // Structs have value equality by default (via reflection, can be slow if not overridden, but records fix this)
        Console.WriteLine($"Struct Equality: {myLocation.Equals(yourLocation)}"); 

        Console.WriteLine("\n------------------\n");

        // 2. Record class
        var tx1 = new BankTransaction(Guid.NewGuid(), 1500m, "Salary", DateTime.Now);
        
        // Using 'with' expression for non-destructive mutation
        var tx2 = tx1 with { Amount = 2000m, Description = "Updated Salary" };
        var tx3 = tx1 with { }; // Exact copy

        Console.WriteLine($"Transaction 1: {tx1}");
        Console.WriteLine($"Transaction 2: {tx2}");
        Console.WriteLine($"Record Class Equality (tx1 == tx3): {tx1 == tx3}"); // True because of value-based equality

        Console.WriteLine("\n------------------\n");

        // 3. Record struct
        var p1 = new Point3D(1.5, 2.0, 3.5);
        var p2 = new Point3D(1.5, 2.0, 3.5);

        Console.WriteLine($"Point3D: {p1}");
        Console.WriteLine($"Record Struct Equality (p1 == p2): {p1 == p2}"); // True, generated efficiently by compiler
    }
}
