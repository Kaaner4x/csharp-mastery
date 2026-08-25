namespace Generics.Models;

public class Customer : EntityBase
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Customer: {FullName} - Email: {Email}";
    }
}
