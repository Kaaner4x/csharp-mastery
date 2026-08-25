namespace CSharp.Mastery.ArraysAndCollections.Models;

public class InventoryItem
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class ActionLog
{
    public string ActionType { get; set; } = string.Empty;
    public InventoryItem Item { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
