# Bölüm 12: Delegates and Events (Temsilciler ve Olaylar)

## 1. Teorik Altyapı ve Çalışma Mantığı

C#'ta **Delegates (Temsilciler)**, metotları referans olarak tutabilen, tip güvenli (type-safe) fonksiyon işaretçileridir (function pointers). Metotların başka metotlara parametre olarak geçirilmesini veya sonradan çalıştırılmasını (callback) sağlarlar. **Events (Olaylar)** ise delegelerin sarmalanmış (encapsulated) ve güvenli hale getirilmiş (sadece tanımlandığı sınıf içinden tetiklenebilen) versiyonlarıdır. Observer (Gözlemci) tasarım deseninin C#'taki doğal uygulamasıdır.

### Delegate Türleri
- **Özel Delegate Tanımları:** `public delegate void MyDelegate(string msg);`
- **Action:** Geriye değer döndürmeyen (void) metotları temsil eder. En fazla 16 parametre alabilir.
- **Func:** Geriye bir değer döndüren metotları temsil eder. Son jenerik parametre dönüş tipini belirtir. (Örn: `Func<int, int, bool>`)
- **Predicate:** Sadece geriye `bool` döndüren ve tek parametre alan özel bir Func türevidir. Genellikle filtreleme işlemlerinde (örn. `FindAll`) kullanılır.

### Bellek Yönetimi ve Delegate'ler
- Delegate'ler referans tipleridir ve heap bellekte tutulurlar. 
- Delegate'ler `MulticastDelegate` sınıfından türerler, yani birden fazla metodu `+=` operatörü ile zincirleme olarak bağlayabilirsiniz. Çağrıldıklarında bağlı tüm metotlar sırayla çalışır.
- **Memory Leak Tehlikesi:** Event abonelikleri (`+=`), abone olan nesneyi event'i yayınlayan (publisher) nesne tarafından referanslı tutar. Eğer uzun ömürlü bir publisher nesnesine abone olan kısa ömürlü nesneler, aboneliklerini iptal etmezse (`-=`), Garbage Collector bu nesneleri temizleyemez ve bellek sızıntısı (memory leak) oluşur. C#'ta bellek sızıntılarının en yaygın nedenlerinden biri un-subscribed event'lerdir.

## 2. Mülakat Soruları ve Cevapları

**Soru 1: Delegate ve Event arasındaki temel fark nedir? Neden direkt public bir delegate yerine event kullanmalıyız?**
**Cevap:** Delegate bir veri tipidir ve sınıf dışında da tetiklenebilir veya null'a çekilebilir. Event ise delegate üzerine bir koruma (encapsulation) katmanı ekler. Bir event, dışarıdan sadece `+=` ve `-=` operatörleriyle abone olunabilir veya abonelikten çıkılabilir, ancak sınıfın dışından tetiklenemez (invoke edilemez) ve sıfırlanamaz (null atanamaz). Bu da güvenliği sağlar.

**Soru 2: Action, Func ve Predicate arasındaki fark nedir?**
**Cevap:** 
- `Action` geriye değer döndürmez (`void`).
- `Func` geriye her zaman bir değer döndürür.
- `Predicate` her zaman geriye `bool` döndürür ve tek parametre alır (aslında `Func<T, bool>` ile aynı işlevi görür).

**Soru 3: Event aboneliklerinde bellek sızıntısını (memory leak) önlemek için ne yapmalısınız?**
**Cevap:** Abonelik ihtiyacı bittiğinde mutlaka `-=` operatörü ile abonelik iptal edilmelidir (unsubscribe). Özellikle `IDisposable` implemente eden sınıflarda, `Dispose` metodu içinde event abonelikleri temizlenmelidir. Alternatif olarak Weak Events pattern kullanılabilir.

## 3. Gerçek Hayat Senaryosu: Video İşleme ve Bildirim Sistemi

Bu senaryoda, uzun süren bir video kodlama (encoding) sürecini simüle edeceğiz. 
Süreç başladığında, ilerlediğinde ve bittiğinde çeşitli dış sistemlere (E-Posta Servisi, SMS Servisi) bildirimler gönderilmesi gerekmektedir. Observer pattern kullanılarak, VideoEncoder sınıfının dış servislerden haberdar olmadan olayları tetiklemesi sağlanacaktır. Ayrıca Action, Func ve Predicate kullanım örneklerine de yer verilecektir.
