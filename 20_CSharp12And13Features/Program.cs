using System;
using _20_CSharp12And13Features.Models;
using _20_CSharp12And13Features.Services;

namespace _20_CSharp12And13Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# 12 & 13 Features Demo\n");

            // Primary Constructor kullanımı (Model oluşturma)
            var customer = new Customer(1, "Emir", "emir@example.com");
            Console.WriteLine($"Customer Created: {customer.Name} ({customer.Email})");

            var processor = new OrderProcessor();
            
            // Collection Expressions ve Spread Operator kullanımı
            int[] electronics = [1001, 1002];   // C# 12 Collection Expression
            int[] books = [2001, 2002, 2003];

            // İki listeyi spread operatörü (..) ile birleştirme
            int[] cart = [.. electronics, 3001, .. books];
            
            Console.WriteLine("\nProcessing Order with items:");
            foreach (var item in cart)
            {
                Console.WriteLine($"- Item ID: {item}");
            }

            // ref readonly simülasyonu
            // Büyük bir struct düşünelim
            OrderSummary summary = new OrderSummary { TotalAmount = 150.5m, ItemCount = cart.Length };
            processor.DisplaySummary(ref summary);
        }
    }
}
