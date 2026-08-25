using Generics.Data;
using Generics.Models;
using Generics.CovarianceContravariance;

namespace Generics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== C# Mastery: 11 - Generics ===");
        
        // 1. Generic Repository Pattern Kullanımı
        Console.WriteLine("\n--- Generic Repository (Product) ---");
        IRepository<Product> productRepo = new Repository<Product>();
        
        var product1 = new Product { Name = "Laptop", Price = 25000m, Stock = 10 };
        var product2 = new Product { Name = "Mouse", Price = 500m, Stock = 100 };
        
        productRepo.Add(product1);
        productRepo.Add(product2);
        
        productRepo.Delete(product2.Id); // Mouse silindi (soft delete)
        
        foreach (var p in productRepo.GetAll())
        {
            Console.WriteLine(p);
        }
        
        Console.WriteLine("\n--- Generic Repository (Customer) ---");
        IRepository<Customer> customerRepo = new Repository<Customer>();
        customerRepo.Add(new Customer { FullName = "Emir Doe", Email = "emir@example.com" });
        
        foreach (var c in customerRepo.GetAll())
        {
            Console.WriteLine(c);
        }

        // 2. Covariance (out) ve Contravariance (in) Kullanımı
        Console.WriteLine("\n--- Covariance ve Contravariance ---");
        
        // Covariance (out): Product üreten bir nesne, EntityBase üreten bir nesne olarak kabul edilebilir.
        // Çünkü Product, EntityBase'den türemiştir.
        IProducer<Product> productProducer = new EntityProducer<Product>();
        IProducer<EntityBase> entityProducer = productProducer; 
        EntityBase generatedEntity = entityProducer.Produce();
        Console.WriteLine($"[Covariance] Üretilen Nesne: {generatedEntity.GetType().Name}");

        // Contravariance (in): EntityBase tüketen bir nesne, Product tüketen bir nesne olarak kullanılabilir.
        // Çünkü EntityBase için geçerli olan operasyonlar Product için de geçerlidir.
        IConsumer<EntityBase> baseConsumer = new EntityConsumer<EntityBase>();
        IConsumer<Product> productConsumer = baseConsumer;
        productConsumer.Consume(new Product());
        
        Console.WriteLine("\nİşlemler tamamlandı.");
    }
}
