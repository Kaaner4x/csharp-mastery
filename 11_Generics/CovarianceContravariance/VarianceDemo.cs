using Generics.Models;

namespace Generics.CovarianceContravariance;

// Covariance (out) - Sadece dönüş tipi olarak kullanılabilir. Alt tipler, üst tiplerine atanabilir.
public interface IProducer<out T>
{
    T Produce();
}

public class EntityProducer<T> : IProducer<T> where T : new()
{
    public T Produce() => new T();
}

// Contravariance (in) - Sadece parametre tipi olarak kullanılabilir. Üst tipler, alt tiplerin yerine atanabilir.
public interface IConsumer<in T>
{
    void Consume(T item);
}

public class EntityConsumer<T> : IConsumer<T>
{
    public void Consume(T item)
    {
        Console.WriteLine($"[Consumer] İşlenen tip: {item?.GetType().Name}");
    }
}
