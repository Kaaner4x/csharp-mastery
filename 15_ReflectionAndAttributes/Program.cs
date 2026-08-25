using ReflectionAndAttributes.Models;
using ReflectionAndAttributes.Validation;
using ReflectionAndAttributes.Orm;

namespace ReflectionAndAttributes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== C# Mastery: 15 - Reflection and Attributes ===\n");

        // Hatalı bir User nesnesi oluşturuyoruz
        var invalidUser = new User 
        { 
            Id = 1, 
            Name = "Bu isim kesinlikle elli karakterden daha uzundur ve validasyonu gecemeyecektir", 
            Email = "" // Required
        };

        Console.WriteLine("--- 1. Validasyon Motoru (Reflection + Attributes) ---");
        if (!Validator.Validate(invalidUser, out var errors))
        {
            Console.WriteLine("Doğrulama Hataları Bulundu:");
            foreach (var error in errors)
            {
                Console.WriteLine($"- {error}");
            }
        }

        Console.WriteLine("\n--- 2. Simple ORM SQL Jeneratörü (Reflection + Attributes) ---");
        // Geçerli bir User nesnesi
        var validUser = new User
        {
            Id = 2,
            Name = "Emir",
            Email = "emir@example.com"
        };

        // Arka planda Reflection kullanarak class'ın attribute'larını okuyup SQL üretecek
        string insertQuery = SimpleOrm.GenerateInsertSql(validUser);
        Console.WriteLine("Üretilen SQL Sorgusu:");
        Console.WriteLine(insertQuery);
        
        // Reflection ile nesnenin tip bilgilerini ekrana yazdırma
        Console.WriteLine("\n--- 3. Temel Reflection Bilgileri ---");
        Type type = typeof(User);
        Console.WriteLine($"Tip Adı: {type.Name}");
        Console.WriteLine($"Namespace: {type.Namespace}");
        Console.WriteLine("Metotlar:");
        foreach (var method in type.GetMethods().Where(m => m.IsSpecialName == false)) // get_ set_ metotlarını gizle
        {
            Console.WriteLine($"- {method.Name}");
        }

        Console.WriteLine("\nİşlemler tamamlandı.");
    }
}
