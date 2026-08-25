using CSharp.Mastery.OperatorsAndPatternMatching.Models;

namespace CSharp.Mastery.OperatorsAndPatternMatching.Services;

public class ShippingCalculatorService
{
    public decimal CalculateCost(ShippingDetails details)
    {
        decimal baseCost = 50m; // Taban fiyat

        // 1. Relational Patterns ile mesafe hesaplama (Switch Expression)
        decimal distanceMultiplier = details.DistanceInKm switch
        {
            < 0 => throw new ArgumentException("Mesafe negatif olamaz!"),
            <= 100 => 1.0m, // Yakın mesafe
            > 100 and <= 500 => 1.5m, // Orta mesafe
            > 500 and <= 1000 => 2.0m, // Uzun mesafe
            _ => 3.0m // 1000km üzeri
        };

        // 2. List Patterns ile boyut analizi (C# 11)
        // [En, Boy, Yükseklik]
        decimal dimensionMultiplier = details.Dimensions switch
        {
            // Eğer dizi tam olarak boşsa
            [] => throw new ArgumentException("Boyut bilgisi eksik!"),
            
            // İlk eleman 100'den büyükse, geri kalanı ne olursa olsun (Hacimli Kargo)
            [> 100, ..] => 2.5m,
            
            // Tüm boyutlar 10'dan küçük veya eşitse (Küçük Paket)
            [<= 10, <= 10, <= 10] => 0.8m,
            
            // Tam 3 boyutu var ama spesifik şartlara uymuyorsa standart
            [_, _, _] => 1.2m,
            
            // Diğer tüm durumlar (Örn: Hatalı giriş, 2 elemanlı vs.)
            _ => 1.0m
        };

        decimal totalCost = baseCost * distanceMultiplier * dimensionMultiplier;

        // 3. Flags Enum & Bitwise (Bitsel) Operatörler
        // .HasFlag() metodu kullanılabilir ancak arka planda (Options & Ekspress) == Ekspress mantığı çalışır.
        
        // Ekspres Kargo kontrolü (Bitwise AND)
        if ((details.Options & ShippingOptions.Express) == ShippingOptions.Express)
        {
            totalCost += 100m; // 100 TL ekstra hızlı gönderim ücreti
        }

        // Sigorta kontrolü
        if ((details.Options & ShippingOptions.Insured) == ShippingOptions.Insured)
        {
            totalCost *= 1.10m; // %10 sigorta primi
        }

        // Kırılacak eşya paketleme maliyeti
        if (details.Options.HasFlag(ShippingOptions.Fragile))
        {
            totalCost += 30m;
        }

        return totalCost;
    }
}
