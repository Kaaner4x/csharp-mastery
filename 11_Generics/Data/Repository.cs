using Generics.Models;

namespace Generics.Data;

/// <summary>
/// InMemory Generic Repository Uygulaması.
/// Veritabanı bağlamı simüle edilmiştir.
/// </summary>
public class Repository<T> : IRepository<T> where T : EntityBase, new()
{
    // Verileri hafızada tutacağımız jenerik koleksiyon
    private readonly List<T> _dataContext = new();

    public void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dataContext.Add(entity);
        Console.WriteLine($"[Repository] {typeof(T).Name} eklendi: {entity.Id}");
    }

    public void Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            // Soft delete uyguluyoruz
            entity.IsDeleted = true;
            Console.WriteLine($"[Repository] {typeof(T).Name} silindi (Soft Delete): {id}");
        }
    }

    public IEnumerable<T> GetAll()
    {
        // Silinmemiş verileri getiriyoruz
        return _dataContext.Where(x => !x.IsDeleted).ToList();
    }

    public T? GetById(Guid id)
    {
        return _dataContext.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
    }

    public void Update(T entity)
    {
        var existingEntity = GetById(entity.Id);
        if (existingEntity != null)
        {
            // Gerçek bir senaryoda ORM (örn. EF Core) kullanılarak update edilir.
            // Biz burada obje referansı üzerinden manuel property mapleme simülasyonu yapıyoruz.
            var index = _dataContext.IndexOf(existingEntity);
            _dataContext[index] = entity;
            Console.WriteLine($"[Repository] {typeof(T).Name} güncellendi: {entity.Id}");
        }
    }
}
