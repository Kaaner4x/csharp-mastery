using System;
using _19_DesignPatterns.Factories;
using _19_DesignPatterns.Services;
using _19_DesignPatterns.Models;

namespace _19_DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns Demo\n");

            // 1. Singleton Pattern Kullanımı
            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;

            // İki logger da aynı instance mı?
            Console.WriteLine($"Are logger instances same? {ReferenceEquals(logger1, logger2)}\n");

            logger1.Log("Application started.");

            // 2. Factory Method Pattern Kullanımı
            var invoice = DocumentFactory.CreateDocument("invoice");
            invoice.Print();

            var report = DocumentFactory.CreateDocument("report");
            report.Print();
            
            logger1.Log("Documents created and printed.");
            
            Console.WriteLine("\nDesign Patterns demo completed.");
        }
    }
}
