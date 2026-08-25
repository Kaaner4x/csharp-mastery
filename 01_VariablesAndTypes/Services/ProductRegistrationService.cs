using CSharp.Mastery.VariablesAndTypes.Models;

namespace CSharp.Mastery.VariablesAndTypes.Services;

/// <summary>
/// Ürün kayıt işlemlerini yöneten servis (Reference Type)
/// </summary>
public class ProductRegistrationService
{
    public void RegisterProduct(Product product)
    {
        // 1. Nullable Reference Type kullanım örneği
        // Burada product.Description null olabileceğinden C# derleyicisi bizi uyarır.
        // Null kondisyonel operatör (?) kullanarak güvenli erişim sağlıyoruz.
        int descriptionLength = product.Description?.Length ?? 0;

        Console.WriteLine($"[SİSTEM] '{product.Name}' adlı ürün sisteme kaydediliyor...");
        Console.WriteLine($"[SİSTEM] Açıklama uzunluğu: {descriptionLength} karakter.");

        // 2. Raw String Literals (C# 11)
        // Kaçış karakterlerine gerek kalmadan JSON formatında loglama stringi oluşturma
        string jsonLog = $$"""
            {
                "Event": "ProductRegistered",
                "Timestamp": "{{DateTime.UtcNow:O}}",
                "ProductData": {
                    "Id": "{{product.Id}}",
                    "Name": "{{product.Name}}",
                    "Price": {{product.Price}},
                    "Dimensions": {
                        "W": {{product.Dimensions.Width}},
                        "H": {{product.Dimensions.Height}},
                        "D": {{product.Dimensions.Depth}},
                        "Weight": {{product.Dimensions.WeightInKg}}
                    }
                }
            }
            """;

        Console.WriteLine("\n[LOG] Elasticsearch'e gönderilecek veri:");
        Console.WriteLine(jsonLog);
        Console.WriteLine("\n[SİSTEM] Ürün başarıyla kaydedildi.\n");
    }
}
