using CSharp.Mastery.ArraysAndCollections.Models;

namespace CSharp.Mastery.ArraysAndCollections.Services;

public class InventoryManager
{
    // Hızlı arama için Dictionary (O(1) Karmaşıklığı)
    private readonly Dictionary<string, InventoryItem> _stockBySku = new();
    
    // Benzersiz kategoriler için HashSet
    private readonly HashSet<string> _categories = new();
    
    // İşlenmeyi bekleyen siparişler (FIFO)
    private readonly Queue<InventoryItem> _processingQueue = new();
    
    // Yapılan işlemleri geri almak için (LIFO)
    private readonly Stack<ActionLog> _undoStack = new();

    public void AddItemToStock(string sku, string name, int quantity)
    {
        var item = new InventoryItem { Sku = sku, Name = name, Quantity = quantity };
        
        // Dictionary'ye ekleme
        _stockBySku[sku] = item;
        
        // İşlem kaydını Stack'e ekle
        _undoStack.Push(new ActionLog { ActionType = "Add", Item = item });
        
        Console.WriteLine($"[Envanter] {name} eklendi. (Stok: {quantity})");
    }

    public void AddCategory(string category)
    {
        // HashSet, eleman zaten varsa false döner ve eklemez.
        if (_categories.Add(category))
        {
            Console.WriteLine($"[Kategori] Yeni kategori eklendi: {category}");
        }
        else
        {
            Console.WriteLine($"[Kategori] '{category}' zaten mevcut.");
        }
    }

    public void QueueForProcessing(string sku)
    {
        if (_stockBySku.TryGetValue(sku, out var item))
        {
            _processingQueue.Enqueue(item);
            Console.WriteLine($"[Kuyruk] {item.Name} işlem sırasına alındı. Bekleyen sayısı: {_processingQueue.Count}");
        }
    }

    public void ProcessNextInQueue()
    {
        if (_processingQueue.TryDequeue(out var item))
        {
            Console.WriteLine($"[İşleniyor] {item.Name} kuyruktan çıkarıldı ve işlendi.");
        }
    }

    public void UndoLastAction()
    {
        if (_undoStack.TryPop(out var lastAction))
        {
            if (lastAction.ActionType == "Add")
            {
                _stockBySku.Remove(lastAction.Item.Sku);
                Console.WriteLine($"[Geri Al (Undo)] {lastAction.Item.Name} envanterden silindi.");
            }
        }
    }

    // Yüksek Performanslı String Analizi (Span<T>)
    // Gelen Barkod Formatı: "COUNTRY-CATEGORY-SKU" -> "TR-ELEC-MAC123"
    public void ParseBarcodeHighPerformance(string barcode)
    {
        // Kopyalama yapmadan (Substring kullanmadan) string belleğinde geziniyoruz.
        ReadOnlySpan<char> barcodeSpan = barcode.AsSpan();
        
        int firstDash = barcodeSpan.IndexOf('-');
        int secondDash = barcodeSpan.LastIndexOf('-');

        if (firstDash > 0 && secondDash > firstDash)
        {
            ReadOnlySpan<char> country = barcodeSpan.Slice(0, firstDash);
            ReadOnlySpan<char> category = barcodeSpan.Slice(firstDash + 1, secondDash - firstDash - 1);
            ReadOnlySpan<char> sku = barcodeSpan.Slice(secondDash + 1);

            Console.WriteLine($"[Span Analizi] Ülke: {country.ToString()}, Kategori: {category.ToString()}, SKU: {sku.ToString()}");
        }
    }
}
