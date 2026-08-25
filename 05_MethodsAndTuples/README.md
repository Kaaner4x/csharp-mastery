# C# Mastery: Metotlar ve Tuple'lar (Methods and Tuples)

Bir yazılımın fonksiyonelliği ve tekrar kullanılabilirliği (Reusability) tamamen metotların doğru tasarlanmasına bağlıdır. Bu modülde parametre geçiş tiplerini (`ref`, `out`, `in`), metotların içinden birden fazla değer dönmenin modern yolu olan Tuple yapılarını ve kodu sadeleştiren Local Functions (Yerel Metotlar) kavramlarını inceleyeceğiz.

## Teorik Altyapı

### 1. Parametre Geçiş Çeşitleri (ref, out, in)
C#'ta varsayılan olarak değer tipleri kopyalanarak, referans tipleri ise adres kopyalanarak gönderilir. Ancak bazı durumlarda bu davranışı değiştirmek isteriz:
- **ref:** Metoda gönderilen değişkenin orijinal bellek adresini gönderir. Metot içinde yapılan değişiklik, çağıran yerdeki orijinal değişkeni etkiler. Değişken metoda verilmeden önce *mutlaka* başlatılmış (initialize) olmalıdır.
- **out:** `ref` gibidir, referans gönderir. Ancak metoda gönderilirken değişkenin başlatılmış olmasına gerek yoktur. Bunun bedeli olarak, metodun içinde bu değişkene *mutlaka* bir değer atanması (set edilmesi) zorunludur. (Sıklıkla `int.TryParse` metodunda görürüz).
- **in:** C# 7.2 ile geldi. Verinin referansını gönderir (büyük `struct` tiplerinde kopyalama maliyetini önler) ama metot içinde bu değişkenin değiştirilmesini (readonly) **yasaklar**. Güvenli ve performanslı veri aktarımı sağlar.

### 2. Tuples (ValueTuple)
C# 7.0 öncesi bir metottan birden fazla değer döndürmek için ya bir sınıf (class/struct) oluşturmak ya da `out` parametreleri kullanmak gerekiyordu. `ValueTuple` yapısı sayesinde metotlar artık oldukça şık bir sözdizimi ile birden fazla veriyi döndürebilir. Tuples, Stack bellekte tutulan `struct` yapılarıdır.

```csharp
public (bool IsSuccess, string Message) ProcessPayment() 
{
    return (true, "Ödeme Başarılı");
}
```

### 3. Local Functions (Yerel Metotlar)
Bir metodun sadece içinde çağrılabilen, o metoda özel yardımcı (helper) metotlar tanımlayabiliriz. Yalnızca bir yerde kullanılan kod parçalarını sınıf seviyesine çıkarmak yerine ait oldukları metodun içine gizleyerek (Encapsulation) temiz bir yapı kurarız.

### 4. Optional Parameters (Opsiyonel Parametreler)
Parametrelere varsayılan (default) değerler atayarak, metodu çağıran kişiyi bu değerleri vermek zorunda bırakmayız.

## Mülakat Soruları ve Cevapları

**Soru 1: `ref` ve `out` arasındaki fark nedir?**
**Cevap:** İkisi de referans ile parametre aktarır. Ancak `ref` ile gönderilecek değişkenin öncesinde bir değere sahip olması şarttır ve metot içinde değiştirilme zorunluluğu yoktur. `out` ile gönderilen değişkenin başlangıç değeri olmak zorunda değildir ancak metot içinde mutlaka bir değere atanmak zorundadır.

**Soru 2: Büyük bir `struct`'ı parametre olarak metoda gönderirken performansı nasıl artırırsınız?**
**Cevap:** `struct` bir değer tipidir ve normalde değeri kopyalanarak gider. Büyük bir struct kopyalamak maliyetlidir. Bunun yerine parametreyi `in` anahtar kelimesiyle gönderirim. Böylece sadece adresi (referansı) gider, kopyalama maliyeti biter ve `in` sayesinde metot içinde kazara değiştirilmesi engellenmiş olur.

**Soru 3: Tuple varken neden metottan class veya struct dönelim?**
**Cevap:** Tuple'lar geçici ve basit veri gruplamaları için harikadır. Ancak dönen verinin karmaşık davranışları, encapsulation kuralları veya OOP'ye uygun metotları olacaksa `class` veya `struct` (Record) dönmek daha doğru bir mimaridir.

## Gerçek Hayat Senaryosu: Sipariş İşleme Servisi
Bir e-ticaret uygulamasında sipariş işleme senaryosu kurgulayacağız.
- Ödeme doğrulama işlemi için birden fazla sonuç dönebilen `Tuple`.
- Büyük sipariş detayları struct'ını kopyalamadan okumak için `in` parametresi.
- İndirim kuponu uygulamasında referans üzerinden değişiklik için `ref`.
- Geçerli vergi hesaplamasında `out` kullanımı.
- Yardımcı doğrulama fonksiyonları için `Local Functions`.
