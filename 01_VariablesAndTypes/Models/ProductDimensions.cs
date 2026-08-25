namespace CSharp.Mastery.VariablesAndTypes.Models;

/// <summary>
/// Bir ürünün fiziksel boyutlarını temsil eden Değer Tipi (Value Type - struct).
/// Stack bellekte tutulur. Kopyalandığında tüm alanlar kopyalanır.
/// </summary>
public struct ProductDimensions
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double WeightInKg { get; set; }

    public ProductDimensions(double width, double height, double depth, double weightInKg)
    {
        Width = width;
        Height = height;
        Depth = depth;
        WeightInKg = weightInKg;
    }
}
