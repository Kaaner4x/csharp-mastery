namespace CSharp.Mastery.StructsAndRecords.Models;

// Record struct (value type). Combines the value-type semantics of a struct 
// with the compiler-generated features of a record (equality, ToString, etc.).
public readonly record struct Point3D(double X, double Y, double Z);
