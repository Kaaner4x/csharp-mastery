# Modül 9: Yapılar (Structs) ve Kayıtlar (Records)

## Temel Kavramlar

### Structs (Yapılar)
`struct`, C#'ta değer tiplerini (value types) tanımlamak için kullanılır. 
- Sınıfların aksine, yapılar genellikle **Stack** belleğinde tutulur (eğer başka bir sınıfın parçası değillerse).
- Küçük boyutlu, veriyi tutmaktan başka bir görevi olmayan tipler için performansı artırmak amacıyla kullanılırlar (Örn: `DateTime`, `int`, `Guid`, koordinatlar).
- `readonly struct`: Verinin oluşturulduktan sonra asla değiştirilemeyeceğini (Immutable) garanti eder. Bu, derleyicinin gizli kopyalamaları (defensive copies) engellemesini sağlayarak performansı artırır.

### Records (Kayıtlar) - C# 9.0 ve Sonrası
`record`, temel amacı veriyi kapsüllemek olan (Data-centric) tipler oluşturmak için tasarlanmış bir referans tipidir (`record class`).
C# 10 ile birlikte `record struct` tanıtılarak değer tipi varyasyonu da eklenmiştir.

Özellikleri:
1. **Value-Based Equality (Değer Tabanlı Eşitlik):** Normalde sınıflarda (class) `==` operatörü bellek adreslerini (referansları) karşılaştırır. Ancak record'larda özelliklerin (property) taşıdığı değerler karşılaştırılır.
2. **Non-destructive Mutation (`with` expression):** Veriyi değiştirmek yerine, değişmiş halini içeren yeni bir kopya oluşturmanızı sağlar. Bu sayede Immutability (Değişmezlik) korunur.
3. **Positional Syntax:** Tek satırda kurucu metot ve property tanımlamaya olanak tanır.
4. **Built-in Formatting:** Otomatik olarak okunabilir bir `ToString()` implementasyonu sunar.

## Immutability (Değişmezlik)

Bir nesnenin oluşturulduktan sonra durumunun (state) değiştirilememesidir.
- **Neden Önemli?** Çok iş parçacıklı (multi-threaded) uygulamalarda thread-safety (iş parçacığı güvenliği) sağlar. Veri yarışması (race condition) olmaz. Hata ayıklaması çok daha kolaydır, çünkü nesnenin durumu öngörülebilirdir.

## Bellek Yönetimi

- `class` ve `record class`: Heap üzerinde tahsis (allocate) edilir. Garbage Collector (GC) tarafından yönetilir.
- `struct` ve `record struct`: Yerel değişken olarak kullanıldıklarında Stack üzerinde yaşarlar. GC'ye yük oluşturmazlar. Boyutu küçük (genellikle < 16 byte) veriler için idealdirler. 

## Sık Sorulan Mülakat Soruları

1. **Struct ile Class arasındaki farklar nelerdir?**
   *Cevap:* Struct değer tipidir (Stack), Class referans tipidir (Heap). Struct kalıtımı (inheritance) desteklemez, Class destekler. Struct'lar null olamaz (Nullable struct hariç), Class'lar olabilir.
2. **Record neden icat edildi, Class varken neden kullanalım?**
   *Cevap:* DTO (Data Transfer Object), CQRS Komutları (Commands) veya Domain olayları (Events) gibi sadece veri taşıyan ve değer eşitliği aradığımız tipler için bolca yazılması gereken "boilerplate" kodu (IEquatable uygulamaları, ToString ezişi, hashcode oluşturma) ortadan kaldırmak için.
3. **`with` anahtar kelimesi nasıl çalışır?**
   *Cevap:* Mevcut nesnenin sığ bir kopyasını (shallow copy) çıkarır ve sadece belirtilen alanların değerlerini değiştirerek yeni bir referans döndürür.

## Gerçek Hayat Senaryosu: Koordinatlar ve Finansal İşlemler

- **GpsCoordinate (`readonly struct`):** Harita sistemlerinde milyonlarca koordinat tutulabilir. GC'ye yük bindirmemek ve veriyi güvenli tutmak (immutable) için `readonly struct` kullanılmıştır.
- **BankTransaction (`record class`):** Finansal işlemlerde geçmişe dönük değişiklik yapılmamalıdır (Immutability). Ayrıca aynı veriye sahip iki farklı log veya işlem geldiğinde bunların aynı olduğunu anlayabilmek için (Value-equality) record yapısı tercih edilmiştir.
- **Point3D (`record struct`):** Hem değer tipi olması (performans) hem de `record` yeteneklerine sahip olması istenen veri türleri içindir.
