using Generics.Models;

namespace Generics.Data;

/// <summary>
/// Generic Repository Arayüzü
/// Kısıtlamalar:
/// T kesinlikle bir class (referans tip) olmalı.
/// T aynı zamanda EntityBase sınıfından türemiş olmalı.
/// </summary>
/// <typeparam name="T">Entity tipi</typeparam>
public interface IRepository<T> where T : EntityBase, new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
    T? GetById(Guid id);
    IEnumerable<T> GetAll();
}
