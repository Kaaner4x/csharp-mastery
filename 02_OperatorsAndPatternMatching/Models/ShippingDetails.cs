namespace CSharp.Mastery.OperatorsAndPatternMatching.Models;

public class ShippingDetails
{
    public int DistanceInKm { get; set; }
    
    // Boyutlar cm cinsinden (En, Boy, Yükseklik)
    public int[] Dimensions { get; set; } = Array.Empty<int>();
    
    public ShippingOptions Options { get; set; }
}
