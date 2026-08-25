namespace CSharp.Mastery.VariablesAndTypes.Models;

/// <summary>
/// E-Ticaret sistemindeki bir ürünü temsil eden Referans Tipi (Reference Type - class).
/// Nesne Heap bellekte, referansı ise Stack bellekte tutulur.
/// </summary>
public class Product
{
    // C# 11 Nullable Reference Types özelliği aktiftir. 
    // Id asla null olamaz, ancak Description null olabilir.
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } // Nullable referans tipi
    
    public decimal Price { get; set; }
    
    // Değer tipi özelliği
    public ProductDimensions Dimensions { get; set; }

    public Product(string id, string name, decimal price)
    {
        // Null kontrolü, proaktif bir yaklaşımdır.
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price;
    }
}
