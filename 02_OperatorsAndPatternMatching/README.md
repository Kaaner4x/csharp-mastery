# C# Mastery: Operatörler ve Pattern Matching

Bu modülde C#'ta karar kontrol süreçlerini optimize eden modern araçları inceleyeceğiz: Operatörler, Switch Expressions (Switch İfadeleri), Relational Patterns (İlişkisel Desenler), List Patterns ve Flags Enum tabanlı Bitwise (Bitsel) Operatörler.

## Teorik Altyapı

### 1. Pattern Matching (Desen Eşleştirme) - Switch Expressions
C# 8.0 ile hayatımıza giren ve C# 9, 10, 11 ile güçlenen `switch expressions`, geleneksel `switch-case` yapılarını inanılmaz derecede kısaltan, değer döndürmeye odaklı fonksiyonel bir sözdizimidir.

```csharp
var result = status switch 
{
    Status.Active => "Aktif",
    Status.Passive => "Pasif",
    _ => "Bilinmeyen" // Default case
};
```

### 2. Relational ve Logical Patterns
Desen eşleştirmede büyüktür (`>`), küçüktür (`<`), eşittir ve mantıksal operatörler (`and`, `or`, `not`) doğrudan kullanılabilir.
Örnek: `> 100 and <= 500 => "Orta Ölçekli"`

### 3. List Patterns (C# 11)
Diziler veya listeler üzerinde doğrudan desen eşleştirme yapılmasını sağlar. Liste uzunluğunu, elemanların tipini veya değerini pattern üzerinden kontrol edebilirsiniz.
Örnek: `[1, 2, ..] => "İlk iki elemanı 1 ve 2 olan herhangi bir liste"` (`..` slice pattern olarak bilinir).

### 4. Flags Enum ve Bitwise (Bitsel) Operatörler
Enum'ları tek bir değere sahip olmak yerine, aynı anda birden fazla değere sahip olabilecek şekilde tanımlamak için `[Flags]` attribute'ü kullanılır.
Değerler 2'nin üsleri şeklinde verilmelidir (`1, 2, 4, 8, 16...`).
Bitsel operatörler (Bitwise operators):
- `|` (OR): İki bayrağı birleştirmek için.
- `&` (AND): Bir bayrağın var olup olmadığını kontrol etmek için.
- `~` (NOT): Bir bayrağı kaldırmak/tersini almak için.

## Mülakat Soruları ve Cevapları

**Soru 1: Switch Expression ile geleneksel Switch-Case arasındaki fark nedir?**
**Cevap:** Switch Expression daha fonksiyoneldir ve doğrudan bir değer döndürmek (return) üzere tasarlanmıştır. Fall-through (`break` yazmayı unutma hatası) riski taşımaz. Çok daha kısa ve okunaklı bir sözdizimi vardır.

**Soru 2: [Flags] attribute'ü bir enum'a ne kazandırır?**
**Cevap:** Bir enum değişkeninin birden fazla enum değerini (kombinasyon halinde) bitwise operatörleri kullanarak tutabilmesini ve bu değerlerin `ToString()` çağrıldığında virgülle ayrılmış okunabilir metinler vermesini sağlar.

**Soru 3: List Pattern'de `..` (slice) operatörünün görevi nedir?**
**Cevap:** Listenin o kısmında kalan sıfır veya daha fazla elemanı ifade eder (ignore eder). Başlangıç veya bitiş öğelerinin eşleşmesini sağlarken, geri kalan kısmın önemsenmediğini belirtir.

## Gerçek Hayat Senaryosu: Kargo Maliyet Hesaplayıcı
Bir lojistik ve kargo şirketinde, gönderilen paketlerin boyutlarına (List Pattern), uzaklığa (Relational Pattern) ve kargo gönderim özelliklerine (Kırılacak, Ekspres, Sigortalı - Flags Enum) göre akıllı ve optimize bir kargo fiyat hesaplama modülü yazacağız.
