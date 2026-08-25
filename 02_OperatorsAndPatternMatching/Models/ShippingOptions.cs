namespace CSharp.Mastery.OperatorsAndPatternMatching.Models;

/// <summary>
/// Bitwise operatörleri destekleyen Flags Enum yapısı.
/// Değerler 2'nin katları olmalıdır (0, 1, 2, 4, 8, 16...)
/// </summary>
[Flags]
public enum ShippingOptions
{
    None = 0,               // Standart gönderim
    Express = 1 << 0,       // 1 - Hızlı Kargo
    Fragile = 1 << 1,       // 2 - Kırılacak Eşya
    Insured = 1 << 2,       // 4 - Sigortalı Gönderim
    SignatureRequired = 1 << 3 // 8 - İmza Zorunlu
}
