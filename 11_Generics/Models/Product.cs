namespace Generics.Models;

public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    
    public override string ToString()
    {
        return $"Product: {Name} - Price: {Price:C} - Stock: {Stock}";
    }
}
