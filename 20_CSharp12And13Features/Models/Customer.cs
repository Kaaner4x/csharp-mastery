namespace _20_CSharp12And13Features.Models
{
    // C# 12 Primary Constructor
    // Parametreler doğrudan sınıf seviyesinde tanımlanır.
    public class Customer(int id, string name, string email)
    {
        // Gelen parametreleri public property olarak açabiliriz.
        public int Id { get; } = id;
        public string Name { get; } = name;
        public string Email { get; } = email;
        
        // Veya parametreleri sadece sınıf içindeki metotlarda field gibi doğrudan kullanabiliriz
        public void PrintCustomerInfo()
        {
            System.Console.WriteLine($"Info: {name} - {email}");
        }
    }

    public struct OrderSummary
    {
        public decimal TotalAmount { get; set; }
        public int ItemCount { get; set; }
    }
}
