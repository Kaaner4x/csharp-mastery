using CSharp.Mastery.ArraysAndCollections.Services;

namespace CSharp.Mastery.ArraysAndCollections;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Modül 4: Diziler ve Koleksiyonlar ===");

        var inventory = new InventoryManager();

        // 1. Dictionary ve Stack Kullanımı
        inventory.AddItemToStock("SKU001", "Laptop", 50);
        inventory.AddItemToStock("SKU002", "Mouse", 150);

        Console.WriteLine("\nBir hata yaptık, son işlemi geri alalım:");
        inventory.UndoLastAction(); // Mouse silinecek

        // 2. HashSet Kullanımı (Tekillik)
        Console.WriteLine("\nKategori Testi:");
        inventory.AddCategory("Elektronik");
        inventory.AddCategory("Mobilya");
        inventory.AddCategory("Elektronik"); // Tekrar eklemeyecek

        // 3. Queue Kullanımı (Sıraya koyma ve İşleme)
        Console.WriteLine("\nKuyruk Testi:");
        inventory.QueueForProcessing("SKU001");
        inventory.ProcessNextInQueue();

        // 4. Span<T> Yüksek Performanslı Kullanım
        Console.WriteLine("\nSpan<T> ile Kopyalamasız (Zero-Allocation) Metin Analizi:");
        inventory.ParseBarcodeHighPerformance("TR-ELEC-MAC123");
    }
}
