using CSharp.Mastery.OperatorsAndPatternMatching.Models;
using CSharp.Mastery.OperatorsAndPatternMatching.Services;

namespace CSharp.Mastery.OperatorsAndPatternMatching;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Modül 2: Operatörler ve Pattern Matching ===");

        var calculator = new ShippingCalculatorService();

        // Senaryo 1: Standart, küçük paket, yakın mesafe
        var package1 = new ShippingDetails
        {
            DistanceInKm = 45,
            Dimensions = new[] { 8, 8, 8 }, // List pattern: [<= 10, <= 10, <= 10]
            Options = ShippingOptions.None
        };
        Console.WriteLine($"Paket 1 Ücreti: {calculator.CalculateCost(package1):C} (Standart)");

        // Senaryo 2: Uzun mesafe, hacimli, Ekspres ve Sigortalı gönderim (Flags Enum kullanımı)
        // Bitwise OR (|) ile seçenekler birleştiriliyor.
        var package2Options = ShippingOptions.Express | ShippingOptions.Insured | ShippingOptions.Fragile;

        var package2 = new ShippingDetails
        {
            DistanceInKm = 800,
            Dimensions = new[] { 120, 50, 40 }, // List pattern: [> 100, ..]
            Options = package2Options
        };
        
        Console.WriteLine($"\nPaket 2 Ücreti: {calculator.CalculateCost(package2):C}");
        Console.WriteLine($"Paket 2 Seçenekleri: {package2.Options}");

        // Bitwise NOT (~) Kullanımı: Sigortayı kaldırmak istersek
        package2.Options &= ~ShippingOptions.Insured;
        Console.WriteLine($"\nSigorta İptalinden Sonra Paket 2 Seçenekleri: {package2.Options}");
        Console.WriteLine($"Yeni Ücret: {calculator.CalculateCost(package2):C}");
    }
}
