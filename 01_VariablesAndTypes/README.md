# C# Mastery: Değişkenler ve Tipler (Variables and Types)

Bu modülde C# programlama dilindeki temel yapı taşları olan değişkenler, veri tipleri, bellek yönetimi (Stack ve Heap), yeni nesil C# özellikleri (Raw String Literals) ve Nullable Reference Types (Nullable Referans Tipleri) kavramlarını derinlemesine inceleyeceğiz.

## Teorik Altyapı ve Bellek Yönetimi (Stack vs Heap)

C#'ta veri tipleri temelde ikiye ayrılır: **Değer Tipleri (Value Types)** ve **Referans Tipleri (Reference Types)**.

### 1. Değer Tipleri (Value Types)
- `int`, `double`, `bool`, `char`, `struct`, `enum` gibi tiplerdir.
- Belleğin **Stack** bölgesinde tutulurlar.
- Stack, LIFO (Last In First Out) mantığıyla çalışan, oldukça hızlı erişilen ve boyutu/ömrü (scope) derleme zamanında belli olan bellek alanıdır.
- Değer tipleri birbirine atanırken **verinin kopyası** oluşturulur.

### 2. Referans Tipleri (Reference Types)
- `class`, `interface`, `delegate`, `string`, `record` (class bazlı), ve diziler (`array`) referans tipleridir.
- Bu tiplerin referansı (bellek adresi) Stack'te, asıl veri bloğu ise **Heap** bölgesinde tutulur.
- Heap, çalışma zamanında (runtime) dinamik olarak tahsis edilen ve .NET'in **Garbage Collector (GC)** mekanizması tarafından temizlenen esnek bellek alanıdır.
- Referans tipleri birbirine atanırken verinin kopyası değil, **adres kopyası** aktarılır. Yani iki değişken aynı objeyi işaret eder.

> **String İstisnası:** `string` bir referans tipi olmasına rağmen *immutable* (değiştirilemez) bir yapıdadır. Bir string üzerinde değişiklik yapıldığında bellekte yeni bir alan açılır.

## Nullable Reference Types (C# 8.0 ve Sonrası)
Önceden referans tipleri varsayılan olarak `null` alabiliyordu, bu da meşhur `NullReferenceException` hatalarına zemin hazırlıyordu. C# 8.0 ile birlikte gelen Nullable Reference Types özelliği sayesinde referans tiplerinin `null` olup olamayacağını açıkça belirtebiliriz (örn. `string?`). Bu özellik projede `<Nullable>enable</Nullable>` bayrağı ile aktif edilir ve derleyiciyi (compiler) null check yapmaya zorlar.

## Raw String Literals (C# 11.0)
C# 11 ile gelen `"""` (üç veya daha fazla tırnak) sözdizimi, JSON, XML veya uzun metinleri kaçış karakterleri (escape chars) olmadan, doğrudan yazmamızı sağlar. Kodun okunabilirliğini muazzam ölçüde artırır.

## Mülakat Soruları ve Cevapları

**Soru 1: Değer tipi ile referans tipi arasındaki temel fark nedir?**
**Cevap:** Değer tipleri verinin kendisini Stack bellekte tutarken, referans tipleri veriyi Heap bellekte, o veriye ulaşmak için gereken bellek adresini ise Stack bellekte tutar. Değer tiplerinde atama işlemi kopyalama yaparken, referans tiplerinde bellek adresi paylaşılır.

**Soru 2: Garbage Collector (GC) nedir ve hangi bellek bölgesiyle ilgilenir?**
**Cevap:** GC, .NET ortamında Heap bellekte tutulan, artık hiçbir referansı kalmamış olan objeleri otomatik olarak temizleyip belleği işletim sistemine iade eden mekanizmadır. Stack bellekle ilgilenmez çünkü Stack verileri scope bitince (metot sonlanınca) kendiliğinden yok olur.

**Soru 3: String neden referans tipi olmasına rağmen değer tipi gibi davranır?**
**Cevap:** String *immutable* (değiştirilemez) olduğu için. Herhangi bir string manipülasyonunda (örn. birleştirme), mevcut Heap alanı değiştirilmez, Heap'te yeni bir string objesi oluşturulur. Bu nedenle değer atamalarında farklı referanslar oluşmuş gibi güvenli bir davranış sergiler.

**Soru 4: Nullable Reference Types projemizde ne avantaj sağlar?**
**Cevap:** Kod yazımı sırasında (compile time) potansiyel `NullReferenceException` hatalarını yakalamamızı sağlar. Geliştiriciyi nesnenin null olup olmadığını kontrol etmeye (null-check) zorlar, kod kalitesini artırır.

## Gerçek Hayat Senaryosu: E-Ticaret Ürün Kayıt Sistemi
Aşağıdaki projede bir E-Ticaret sisteminin ürün kayıt simülasyonunu göreceksiniz. Kodda `struct` ve `class` kullanımları (Stack/Heap farkı), nullable özellikler ve JSON simülasyonu için Raw String Literals yer almaktadır.
