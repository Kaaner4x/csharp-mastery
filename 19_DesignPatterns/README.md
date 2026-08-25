# C# Design Patterns (Tasarım Desenleri)

Bu modülde yazılım geliştirme sürecinde sıkça karşılaşılan problemlere karşı üretilmiş standart çözümler olan Tasarım Desenlerini inceleyeceğiz. Özellikle Singleton, Factory Method ve Dependency Injection pattern'lerine odaklanacağız.

## 1. Teorik Arka Plan

Tasarım desenleri genel olarak 3 kategoriye ayrılır:
- **Creational (Yaratımsal):** Nesnelerin oluşturulma biçimleriyle ilgilenir. (Singleton, Factory, Builder)
- **Structural (Yapısal):** Nesnelerin ve sınıfların birleşerek daha büyük yapılar kurmasını sağlar. (Adapter, Decorator, Facade)
- **Behavioral (Davranışsal):** Nesneler arası iletişim ve sorumluluk dağıtımıyla ilgilenir. (Observer, Strategy, Command)

### İncelenen Desenler
1. **Singleton Pattern:** Bir sınıfın uygulama boyunca sadece bir örneğinin (instance) olmasını ve bu örneğe global bir erişim noktası sağlanmasını garanti eder. (Örn: Caching, Configuration Manager, Logging)
2. **Factory Method Pattern:** Nesne yaratma işini (new operatörünü) alt sınıflara veya merkezi bir factory metoduna devrederek, istemcinin (client) somut sınıflardan bağımsız olmasını sağlar.
3. **Dependency Injection (DI):** (Mimari Desen/Prensip) Bağımlılıkların nesne içinde yaratılması yerine, dışarıdan enjekte edilmesi (Constructor vb.) esasına dayanır.

## 2. Gerçek Hayat Senaryosu

Senaryomuzda:
- Bir `Logger` sınıfımız var. Log dosyasının aynı anda birden fazla nesne tarafından açılmaya çalışılmasını engellemek ve memory kullanımını optimize etmek için uygulamanın her yerinde aynı Logger instance'ı kullanılmalıdır (Singleton).
- Müşterilerimize fatura (Invoice) veya Rapor (Report) gibi dökümanlar üreten bir sistemimiz var. Döküman türüne göre nesne üretimini `DocumentFactory` (Factory Method) üzerinden merkezi olarak yönetiyoruz.

## 3. Mülakat Soruları

1. **Singleton Pattern'in dezavantajları nelerdir? Neden bazı durumlarda Anti-Pattern olarak kabul edilir?**
   - Singleton, global bir state (durum) yaratır ve bu durum test edilebilirliği (Unit Testing) zorlaştırır. Ayrıca sınıflar arasındaki bağımlılıkları gizler. Günümüzde DI (Dependency Injection) container'larında (örn: `services.AddSingleton()`) yönetilmesi daha çok tercih edilir.
2. **Factory Design Pattern neden kullanılır? `new` anahtar kelimesini kullanmaktan farkı nedir?**
   - İstemci (client), yaratacağı nesnenin somut sınıf ismini bilmek zorunda kalmaz (sadece Interface'i bilir). İleride yeni bir nesne türü sisteme eklendiğinde mevcut istemci kodları değiştirilmez, sadece Factory genişletilir (Open/Closed prensibi).
3. **Thread-Safe Singleton nasıl oluşturulur?**
   - C#'ta en basit yolu `Lazy<T>` tipini kullanmak veya statik değişken oluşturulurken kilit mekanizması (`lock`) kullanmaktır. `static readonly` field başlatımı da .NET'te doğası gereği thread-safe'dir.
