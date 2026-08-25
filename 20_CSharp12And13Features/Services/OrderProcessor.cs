using System;
using _20_CSharp12And13Features.Models;

namespace _20_CSharp12And13Features.Services
{
    public class OrderProcessor
    {
        // ref readonly kullanımı (C# 12)
        // Struct'ın (değer tipinin) kopyalanmasını engellerken,
        // referansın yanlışlıkla değiştirilmesini de engeller.
        public void DisplaySummary(ref readonly OrderSummary summary)
        {
            Console.WriteLine($"\n[OrderSummary] Total Items: {summary.ItemCount}, Amount: ${summary.TotalAmount}");
            
            // summary.TotalAmount = 200; // HATA: ref readonly olduğu için değiştirilemez.
        }
    }
}
