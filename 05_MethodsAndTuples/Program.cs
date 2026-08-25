using CSharp.Mastery.MethodsAndTuples.Models;
using CSharp.Mastery.MethodsAndTuples.Services;

namespace CSharp.Mastery.MethodsAndTuples;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Modül 5: Metotlar ve Tuple'lar ===");

        var service = new OrderProcessingService();

        var order = new OrderDetails
        {
            OrderId = "ORD-2023",
            CustomerName = "Ahmet Yılmaz",
            TotalAmount = 5000m,
            ShippingAddress = "İstanbul, Kadıköy, Merkez Mah."
        };

        // 1. in Parametresi ile Performanslı Aktarım ve Tuple Dönüşü Yakalama
        // Tuple'ın dönen değerlerini deconstruction (parçalama) yöntemi ile anında değişkenlere atıyoruz.
        var (isApproved, reason) = service.ValidateOrder(in order);
        
        Console.WriteLine($"Sipariş Onayı: {isApproved}, Sebep: {reason}");

        if (isApproved)
        {
            decimal currentPrice = order.TotalAmount;
            Console.WriteLine($"\nOrijinal Fiyat: {currentPrice:C}");

            // 2. ref kullanımı ve Optional Parametre (default %10 kullanılacak)
            // ref ile currentPrice referans olarak gidiyor.
            service.ApplyDiscount(ref currentPrice);
            Console.WriteLine($"İndirim Uygulandıktan Sonraki Fiyat: {currentPrice:C}");

            // Farklı bir indirim oranı vererek (Optional parametreyi ezerek)
            service.ApplyDiscount(ref currentPrice, 0.25m); // Ekstra %25 indirim
            Console.WriteLine($"Ekstra İndirimden Sonraki Fiyat: {currentPrice:C}");

            // 3. out kullanımı
            // out parametresi ile değişkeni inline (aynı satırda) deklare edebiliyoruz.
            service.CalculateTax(currentPrice, out decimal calculatedTax);
            
            Console.WriteLine($"\nHesaplanan Vergi Tutarı: {calculatedTax:C}");
            Console.WriteLine($"Müşterinin Ödeyeceği Toplam Tutar: {(currentPrice + calculatedTax):C}");
        }
    }
}
