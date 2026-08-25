# Bölüm 11: Generics (Jenerikler)

## 1. Teorik Altyapı ve Çalışma Mantığı

C# 2.0 ile tanıtılan **Generics**, kodun yeniden kullanılabilirliğini (reusability), tip güvenliğini (type safety) ve performansı artıran en önemli yapı taşlarından biridir. Jenerikler sayesinde, sınıfları, arayüzleri (interfaces) ve metotları, çalışacakları veri tipini önceden belirlemeden tanımlayabiliriz. Veri tipi, nesne örneği oluşturulduğunda veya metot çağrıldığında belirlenir (`<T>`).

### Neden Generics?
- **Tip Güvenliği (Type Safety):** Jenerik olmayan koleksiyonlarda (örn. `ArrayList`) nesneler `object` olarak tutulur. Bu da çalışma zamanında (runtime) tip dönüşümü (casting) hatalarına (örn. `InvalidCastException`) yol açabilir. Generics ile bu hatalar derleme zamanında (compile-time) yakalanır.
- **Performans:** Jenerik olmayan yapılarda, değer tiplerini (value types) referans tiplerine (reference types) atarken **Boxing** (kutuya koyma) ve tekrar değer tipine çevirirken **Unboxing** işlemi gerçekleşir. Bu işlemler ciddi bellek ve CPU maliyetine sahiptir. Generics, boxing/unboxing gereksinimini ortadan kaldırır.

### Bellek Yönetimi ve Generics
Generics, **açık ve kapalı tipler (open and closed constructed types)** mantığıyla çalışır. 
- `List<T>` açık bir tiptir. 
- `List<int>` dendiğinde kapalı (closed) bir tip oluşur.
JIT (Just-In-Time) derleyicisi, değer tipleri (structs) için her bir tipe özel (`List<int>`, `List<double>`) ayrı bir makine kodu üretirken, referans tipleri (`List<string>`, `List<Customer>`) için tek bir ortak makine kodu üretir ve referanslar üzerinden çalışır. Bu sayede referans tipleri için kod şişmesi (code bloat) önlenir, değer tipleri içinse boxing/unboxing engellenerek maksimum performans sağlanır.

## 2. Kısıtlamalar (Constraints - `where`)

Generics kullanırken T tipine belirli kısıtlamalar getirebiliriz:
- `where T : class` -> T sadece referans tip olabilir.
- `where T : struct` -> T sadece değer tip olabilir.
- `where T : new()` -> T'nin parametresiz bir kurucu metodu (constructor) olmalıdır.
- `where T : BaseClass` -> T, belirtilen sınıftan türemiş olmalıdır.
- `where T : IInterface` -> T, belirtilen arayüzü uygulamalıdır (implement).

## 3. Covariance ve Contravariance (Varyans)

C# 4.0 ile arayüzler ve delegelerde kullanılabilecek varyans kavramları geldi:
- **Covariance (Kovaryans - `out`):** Daha spesifik (türemiş) bir tipin, daha genel (temel) bir tip yerine kullanılabilmesidir. Sadece dönüş tiplerinde kullanılır. (Örn. `IEnumerable<out T>`). `IEnumerable<string>`, `IEnumerable<object>` referansına atanabilir.
- **Contravariance (Kontravaryans - `in`):** Daha genel bir tipin, daha spesifik bir tip yerine kullanılabilmesidir. Sadece parametre tiplerinde kullanılır. (Örn. `Action<in T>`).

## 4. Mülakat Soruları ve Cevapları

**Soru 1: ArrayList ile List<T> arasındaki fark nedir? Hangisini tercih edersiniz?**
**Cevap:** `ArrayList` verileri `object` tipinde saklar, bu yüzden tip güvenli değildir ve değer tipleri için boxing/unboxing maliyeti yaratır. `List<T>` jeneriktir, tip güvenliği sağlar ve performansı çok daha yüksektir. Modern C# geliştirmede her zaman `List<T>` tercih edilmelidir.

**Soru 2: `where T : class, new()` kısıtlaması ne anlama gelir?**
**Cevap:** Bu kısıtlama, T olarak gönderilecek tipin mutlaka bir referans tip (class) olması gerektiğini ve aynı zamanda parametresiz bir kurucu metodu (parameterless constructor) barındırması gerektiğini belirtir. Böylece içeride `new T()` şeklinde nesne üretilebilir.

**Soru 3: Covariance (out) ve Contravariance (in) konseptlerini açıklayın.**
**Cevap:** Covariance, bir jenerik tip parametresinin sadece döndürüleceğini (çıktı) garanti eder ve alt sınıfların üst sınıf yerine geçmesine izin verir. Contravariance ise jenerik tip parametresinin sadece metotlara argüman olarak (girdi) verileceğini garanti eder ve üst sınıfın alt sınıf yerine kullanılmasına olanak tanır.

## 5. Gerçek Hayat Senaryosu: Generic Repository Pattern
Bu modülde, veritabanı işlemlerinde sıklıkla karşılaşılan **Generic Repository Pattern** uygulamasını gerçekleştireceğiz. Her Entity (Product, Customer vb.) için ayrı ayrı Ekle, Sil, Güncelle metotları yazmak yerine, tip güvenli ve yeniden kullanılabilir tek bir Repository sınıfı yazarak kod tekrarını önleyeceğiz.
