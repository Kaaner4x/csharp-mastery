using CSharp.Mastery.MethodsAndTuples.Models;

namespace CSharp.Mastery.MethodsAndTuples.Services;

public class OrderProcessingService
{
    // 1. Tuple ve 'in' Parametresi Kullanımı
    // in: Büyük OrderDetails struct'ı bellekte kopyalanmaz, referansı gider ama readonly'dir.
    // Tuple dönüşü: (bool, string)
    public (bool IsApproved, string Reason) ValidateOrder(in OrderDetails order)
    {
        // order.TotalAmount = 0; // HATA! 'in' parametresi sadece okunabilir.

        // 2. Local Function (Yerel Metot) Kullanımı
        // Sadece ValidateOrder içerisinde erişilebilen ve yardımcı iş yapan metot.
        bool IsAddressValid(string address)
        {
            return !string.IsNullOrWhiteSpace(address) && address.Length > 10;
        }

        if (order.TotalAmount <= 0)
            return (false, "Tutar 0 veya negatif olamaz.");

        if (!IsAddressValid(order.ShippingAddress))
            return (false, "Geçersiz teslimat adresi.");

        return (true, "Doğrulama başarılı.");
    }

    // 3. 'ref' Parametresi Kullanımı
    // Metoda giren fiyat, metot içinde değiştiriliyor ve orijinal değişken de etkileniyor.
    public void ApplyDiscount(ref decimal price, decimal discountRate = 0.10m) // Optional parametre (default %10)
    {
        if (price > 0)
        {
            price -= price * discountRate;
        }
    }

    // 4. 'out' Parametresi Kullanımı
    // Vergi tutarını hesaplar. 'out' olduğu için hesaplananVergi metodun içinde mutlaka değer almalıdır.
    public void CalculateTax(decimal price, out decimal taxAmount)
    {
        // taxAmount şu an başlatılmadı. Aşağıda mutlaka değer vermeliyiz.
        taxAmount = price * 0.20m; // %20 KDV
    }
}
