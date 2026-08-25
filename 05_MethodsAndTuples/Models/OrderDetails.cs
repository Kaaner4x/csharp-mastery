namespace CSharp.Mastery.MethodsAndTuples.Models;

/// <summary>
/// Sipariş detaylarını tutan büyük bir Struct.
/// Kopyalanması performans kaybına yol açabileceği için metodlara "in" keywordü ile geçireceğiz.
/// </summary>
public struct OrderDetails
{
    public string OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }
    
    // Simülasyon amaçlı, Struct boyutunu büyüten ekstra alanlar
    public string ExtraNotes1 { get; set; }
    public string ExtraNotes2 { get; set; }
}
