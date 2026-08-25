# Bölüm 15: Reflection and Attributes (Yansıma ve Nitelikler)

## 1. Teorik Altyapı ve Çalışma Mantığı

**Reflection (Yansıma)**, bir uygulamanın çalışma zamanında (runtime) kendi kodunu ve yapısını (Assembly, Module, Type, Metotlar, Property'ler vb.) inceleyebilmesine, bu yapılarla dinamik olarak etkileşime girmesine ve hatta yeni tipler oluşturabilmesine olanak tanıyan güçlü bir mekanizmadır. 

**Attributes (Nitelikler)** ise kod elemanlarına (sınıf, metot, özellik) ekstra meta veriler (metadata) eklememizi sağlayan, köşeli parantezler `[AttributeName]` ile kullanılan özel sınıflardır. Attribute'lar tek başlarına hiçbir şey yapmazlar; ancak Reflection kullanılarak çalışma zamanında okunup bir aksiyon alınmasını sağlarlar (Örn: Model Validation, ORM Mapping, Routing).

### Reflection'ın Kullanım Alanları
- Nesne İlişkisel Eşleme (ORM) araçları (Entity Framework, Dapper).
- Dependency Injection (DI) konteynerleri (Tipleri tarayıp inject etme).
- Serialization / Deserialization (JSON.NET, System.Text.Json).
- Test framework'leri (xUnit, NUnit - `[Fact]` vb. etiketleri bulmak için).

### Bellek Yönetimi ve Performans
- Reflection **ÇOK YAVAŞTIR.** Derleme zamanı (compile-time) denetimlerinden mahrum olduğu ve metaverileri string'ler veya dinamik yollarla aradığı için yüksek CPU ve bellek tahsisi (allocation) maliyeti vardır.
- Yoğun döngüler (tight loops) içinde Reflection kullanmaktan kaçınılmalıdır. 
- Eğer performansa ihtiyaç varsa ve yine de dinamik bir yapı isteniyorsa, Reflection sonuçları **Expression Trees** veya **Emit (IL kod üretimi)** ile derlenerek önbelleğe (cache) alınmalıdır (Bkz: FastMember kütüphanesi). Modern .NET (C# 11+), reflection yerine **Source Generators** (derleme anında kod üretimi) kullanarak bu performans sorununu kökten çözmektedir.

## 2. Mülakat Soruları ve Cevapları

**Soru 1: Reflection'ın avantajları ve dezavantajları nelerdir?**
**Cevap:** 
*Avantaj:* Çok esnek ve dinamik mimariler (plugin sistemleri, ORM'ler, IoC container'lar) kurmaya olanak tanır.
*Dezavantaj:* Performans açısından oldukça yavaştır (tip kontrolü çalışma zamanına kalır). Hatalar (örneğin var olmayan bir metoda erişme) derleme anında değil, sadece runtime anında anlaşılır.

**Soru 2: Bir sınıfın property'lerini reflection ile nasıl alırsınız?**
**Cevap:** `typeof(MyClass).GetProperties()` metodu ile property'ler `PropertyInfo` dizisi olarak elde edilebilir. Nesne üzerinden ise `myObject.GetType().GetProperties()` şeklinde alınır.

**Soru 3: Attribute (Nitelik) tek başına bir iş yapar mı?**
**Cevap:** Hayır, Attribute'lar sadece derlenmiş DLL (assembly) içine metadata (bilgi) olarak yazılırlar. Kodun başka bir yerinde Reflection kullanılarak "Bu sınıfta bu attribute var mı?" diye sorulmadığı sürece pasif ve etkisizdirler.

## 3. Gerçek Hayat Senaryosu: Custom ORM ve Validation Engine
Bu senaryoda:
1. `[Table]` ve `[Column]` attribute'ları tanımlayacağız. `SimpleOrm` sınıfımız, bir nesnenin property'lerini reflection ile tarayarak ona uygun bir "INSERT INTO..." SQL cümlesi üretecek.
2. `[Required]` ve `[MaxLength]` attribute'ları tanımlayarak kendi doğrulama (validation) motorumuzu yazacağız.
