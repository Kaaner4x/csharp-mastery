using CSharp.Mastery.VariablesAndTypes.Models;
using CSharp.Mastery.VariablesAndTypes.Services;

namespace CSharp.Mastery.VariablesAndTypes;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Modül 1: Değişkenler ve Tipler ===");
        
        // 1. Stack'te Değer Tipi (Value Type) oluşturulması
        // Struct'lar 'new' kullanılsa da stack üzerinde konumlandırılır.
        ProductDimensions laptopDimensions = new ProductDimensions(35.5, 2.0, 24.5, 1.8);

        // Değer tiplerinde atama kopyalama yapar.
        ProductDimensions backupDimensions = laptopDimensions;
        backupDimensions.WeightInKg = 2.0; // Sadece backup kopyası değişir, laptopDimensions etkilenmez!

        // 2. Heap'te Referans Tipi (Reference Type) oluşturulması
        Product laptop = new Product("PROD-1001", "MacBook Pro M3", 85000m)
        {
            Description = "Apple M3 çipli, 16GB RAM, 512GB SSD Yüksek Performanslı İş Bilgisayarı",
            Dimensions = laptopDimensions
        };

        // Referans tiplerinde atama adres kopyalar.
        Product referenceCopy = laptop;
        referenceCopy.Price = 89000m; // İkisi de aynı objeyi işaret ettiği için laptop.Price da 89000m olur!

        Console.WriteLine($"Orijinal laptop fiyatı değişti mi?: {laptop.Price:C}");
        Console.WriteLine($"Orijinal laptop ağırlığı değişti mi?: {laptop.Dimensions.WeightInKg} kg (Değişmedi çünkü Struct kopyalandı)\n");

        // 3. Servis kullanımı
        ProductRegistrationService registrationService = new ProductRegistrationService();
        registrationService.RegisterProduct(laptop);
        
        Console.WriteLine("Program başarıyla tamamlandı.");
    }
}
