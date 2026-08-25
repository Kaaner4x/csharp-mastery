namespace Generics.Models;

/// <summary>
/// Tüm veritabanı varlıklarının (entities) türeyeceği temel sınıf.
/// </summary>
public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
