# 🚀 C# Mastery Kapsamlı Laboratuvarı ve Referans Rehberi

**C# ve .NET Ekosisteminde Sıfırdan Uzmanlığa Giden Yol!**

Bu depo (repository), yüzeysel "Merhaba Dünya" örneklerinden arındırılmış; doğrudan gerçek hayat senaryolarına, mülakat sorularına, mimari standartlara ve temiz kod (Clean Code) prensiplerine odaklanan devasa bir C# laboratuvarıdır. 

Bir C# özelliğinin sadece *sözdizimini (syntax)* değil, **"Neden kullanıldığını?"**, **"Bellek (Memory) üzerinde nasıl çalıştığını?"** ve **"Kurumsal (Enterprise) projelerde nasıl modellendiğini"** öğrenmek istiyorsanız doğru yerdesiniz.

---

## 📖 Bu Repoyu Nasıl Kullanmalısınız?

Bu repo, konuların zorluk ve mantık sırasına göre **01'den 20'ye kadar numaralandırılmış klasörlerden** oluşmaktadır. 

1. Her bir klasör, kendi başına bağımsız çalışan bir `.NET 10.0 Console` projesidir.
2. Klasörlerin içine girdiğinizde, konuyu en ince ayrıntısına kadar anlatan, teorik arka planını ve mülakat sorularını içeren özel **`README.md`** dosyaları bulacaksınız. *Lütfen koda bakmadan önce o klasördeki README dosyasını okuyun.*
3. Projeler tek bir `Program.cs` dosyasına sıkıştırılmamıştır. Klasörler içinde `Models`, `Services`, `Interfaces`, `Data` gibi gerçek mimarilere uygun alt dizinler göreceksiniz.

---

## 🗺️ Öğrenim Rotası ve Modüller (Roadmap)

### 🟢 Bölüm 1: Temeller ve Değişkenler
Programlamanın yapıtaşları, bellek yönetimi ve veri manipülasyonu.
*   **[01_VariablesAndTypes](./01_VariablesAndTypes)**: E-Ticaret ürün yönetim sistemi. Stack/Heap yönetimi, Value vs Reference tipler, C# 11 Raw Strings ve Nullable Reference Tipleri.
*   **[02_OperatorsAndPatternMatching](./02_OperatorsAndPatternMatching)**: Kargo ücreti hesaplama motoru. Switch expressions, relational/list patterns, flags enum ve bitsel (bitwise) operasyonlar.
*   **[03_ControlFlowAndLoops](./03_ControlFlowAndLoops)**: Akıllı ATM menüsü simülasyonu. State-machine (durum makinesi) mantığı, döngü performansları ve yönlendirme ifadeleri.
*   **[04_ArraysAndCollections](./04_ArraysAndCollections)**: Envanter (Stok) Yönetim Sistemi. `List`, `Dictionary`, `HashSet`, `Queue`, `Stack` farklılıkları ve yüksek performanslı `Span<T>` ile `Memory<T>` kullanımı.
*   **[05_MethodsAndTuples](./05_MethodsAndTuples)**: Sipariş işleme servisi. `in`, `out`, `ref` parametreleri, Local functions ve Tuple ile birden fazla veri döndürme mimarisi.

### 🟡 Bölüm 2: Nesne Yönelimli Programlama (OOP)
Nesne yönelimli düşünme, kodun tekrar kullanılabilirliği ve soyutlama yetenekleri.
*   **[06_ObjectOrientedProgramming](./06_ObjectOrientedProgramming)**: Araç Kiralama (Rent a Car) Sistemi. Kapsülleme (Encapsulation), Primary Constructors (C# 12) ve Data Validation (Doğrulama).
*   **[07_InheritanceAndPolymorphism](./07_InheritanceAndPolymorphism)**: Şirket Çalışan Hiyerarşisi. `virtual`, `override`, `abstract` sınıflar, `sealed` keyword'ü ile kalıtımın sınırlandırılması.
*   **[08_Interfaces](./08_Interfaces)**: Çoklu Ödeme Geçidi (Iyzico, PayPal entegrasyonları). Bağımlılıkların tersine çevrilmesi (Dependency Inversion), Default Interface Methods (C# 8).
*   **[09_StructsAndRecords](./09_StructsAndRecords)**: GPS Koordinatları ve Banka İşlemleri. Sınıf ve Yapı farkı (`class` vs `struct`), `readonly struct` ve değişmez (Immutable) Record mimarisi.

### 🟠 Bölüm 3: İleri Seviye C# Özellikleri
Esnek, tür-güvenli (type-safe) ve sorgulanabilir modern kod yazma teknikleri.
*   **[10_ExceptionHandling](./10_ExceptionHandling)**: Dış API Bağlantı Yöneticisi. `try-catch-finally`, Custom Exceptions (Özel Hatalar) ve Global Exception Handling deseni.
*   **[11_Generics](./11_Generics)**: Generic Repository Design Pattern. `IRepository<T>`, Constraint'ler (`where T : class`), Covariance ve Contravariance mantığı.
*   **[12_DelegatesAndEvents](./12_DelegatesAndEvents)**: Video İşleme ve Bildirim Sistemi. `Action`, `Func`, `Predicate` kullanımı, Event mekanizması ve Observer Tasarım Deseni.
*   **[13_LINQ](./13_LINQ)**: Şirket Veritabanı Analizi. In-Memory veriler üzerinde Join, GroupBy, SelectMany, Aggregate operasyonları ve Deferred Execution (Ertelenmiş Çalıştırma).

### 🔴 Bölüm 4: Mimari, Performans ve Multithreading (Uzmanlık)
Yüksek performanslı, eşzamanlı ve sürdürülebilir mimariler kurma.
*   **[14_AsynchronousProgramming](./14_AsynchronousProgramming)**: Paralel Hava Durumu Veri Çekimi. `async/await` mimarisi, `Task.WhenAll`, Deadlock (Kilitlenme) önleme ve `IAsyncEnumerable`.
*   **[15_ReflectionAndAttributes](./15_ReflectionAndAttributes)**: Kendi Mini-ORM ve Validasyon aracımızı yazma. Çalışma zamanında (runtime) tip analizi ve nitelik (attribute) okuma.
*   **[16_MemoryManagement](./16_MemoryManagement)**: Ağır Dosya Okuma İşlemleri. Garbage Collector (Çöp Toplayıcı) çalışma prensibi, `IDisposable` arayüzü ve bellek sızıntılarını (Memory Leak) önleme.
*   **[17_ConcurrencyAndMultithreading](./17_ConcurrencyAndMultithreading)**: Bilet Satış Sistemi (Race Condition). Çoklu iş parçacıklarının yönetimi, `lock`, `Mutex`, `SemaphoreSlim` ve thread-safe (eşzamanlı güvenli) koleksiyonlar.
*   **[18_SolidPrinciples](./18_SolidPrinciples)**: Spagetti Kod Refactoring'i. Kötü yazılmış bir Kullanıcı Kayıt Servisinin adım adım SOLID prensiplerine göre yeniden yapılandırılması.
*   **[19_DesignPatterns](./19_DesignPatterns)**: Mimari Standartlar. Singleton (Logger), Factory Method (Belge Üretimi) ve Dependency Injection (Bağımlılık Enjeksiyonu) desenlerinin C# pratikleri.
*   **[20_CSharp12And13Features](./20_CSharp12And13Features)**: En modern yetenekler. Collection expressions, Interceptors, ve modern bellek referans teknikleri.

---

## 🛠️ Nasıl Çalıştırılır?

Projelerin tamamı .NET 10.0 altyapısı üzerine kurulmuştur.

1. Depoyu klonladıktan veya açtıktan sonra, `CSharp.Mastery.slnx` çözüm dosyasını (Solution) **Visual Studio**, **Rider** veya **VS Code** ile açın.
2. Hangi konuyu test etmek istiyorsanız, o projeyi **"Set as Startup Project" (Başlangıç Projesi Olarak Ayarla)** olarak seçin.
3. Projeyi derleyip çalıştırın (`Ctrl + F5` veya `dotnet run`).
4. Konsol ekranındaki interaktif simülasyonları izleyin. Kod içerisindeki satır arası yorumları okuyarak senaryonun akışını öğrenin.

---

## 🎯 Kimler İçin?

*   C# dilinde **"Syntax biliyorum ama projede nasıl kullanacağımı bilmiyorum"** diyenler.
*   Mülakatlara hazırlanan ve konuların **arkasındaki teorik nedeni** (neden struct kullanmalıyız, heap/stack farkı nedir?) ezberlemeden anlamak isteyenler.
*   Mimari (Architecture), SOLID ve Design Patterns konularını doğrudan kod üzerinde pratik etmek isteyenler.
*   Modern C# sürümlerindeki (C# 10/11/12/13) yeni yapıları geride kalmadan projelerine entegre etmek isteyen kıdemli geliştiriciler.

**Kodlamaya Hazırsanız, [01_VariablesAndTypes](./01_VariablesAndTypes) modülü ile ilk adımınızı atabilirsiniz. İyi çalışmalar!**
