# Değişkenler ve Veri Tipleri (Variables)

Değişken isimlendirme kuralları ve veri tipleri hakkında notlar:

* İsimler harfler, rakamlar ve alt çizgi (`_`) içerebilir.
* İsimler bir harf veya alt çizgi ile başlamalıdır.
* İsimler küçük harfle başlamalı ve boşluk içermemelidir.
* Küçük ve büyük harf duyarlılığı vardır (case-sensitive).
* Anahtar kelimeler değişken ismi olarak kullanılamaz (örneğin: `int`, `class`, `void`).

**Değişken tanımlama formatı:**
```csharp
Değişken_türü değişken_adı;
```

### İsimlendirme Standartları

| Standart | Yazım Tarzı (Örnek) | Kullanım Alanı (Genel/C#) |
| --- | --- | --- |
| PascalCase | `KelimeBir`, `ToplamTutar` | Class, Method, Property, Namespace |
| camelCase | `kelimeBir`, `toplamTutar` | Değişken (Variable), Parametre |
| snake_case | `kelime_bir`, `veri_tabani` | SQL Tablo, Python, Dosya İsimleri |
| kebab-case | `kelime-bir`, `stil-adi` | CSS, URL (C#'ta kullanılmaz) |
| UPPER_SNAKE_CASE | `MAX_DEGER`, `API_KEY` | Sabitler (Const) |
| _camelCase | `_baglanti`, `_isim` | Private Field (Sınıf içi global) |

### Veri Tipleri

| Veri Tipi | Kategori | Boyut | Değer Aralığı / Açıklama |
| --- | --- | --- | --- |
| `byte` | Tamsayı (İşaretsiz) | 1 Byte | 0 ile 255 |
| `sbyte` | Tamsayı (İşaretli) | 1 Byte | -128 ile 127 |
| `short` | Tamsayı (İşaretli) | 2 Byte | -32,768 ile 32,767 |
| `ushort` | Tamsayı (İşaretsiz) | 2 Byte | 0 ile 65,535 |
| `int` | Tamsayı (İşaretli) | 4 Byte | -2,147,483,648 ile 2,147,483,647 |
| `uint` | Tamsayı (İşaretsiz) | 4 Byte | 0 ile 4,294,967,295 |
| `long` | Tamsayı (İşaretli) | 8 Byte | -9,223,372,036,854,775,808 ile 9,223,372,036,854,775,807 |
| `ulong` | Tamsayı (İşaretsiz) | 8 Byte | 0 ile 18,446,744,073,709,551,615 |
| `float` | Kesirli Sayı | 4 Byte | ±1.5 x 10^-45 ile ±3.4 x 10^38 (~7 basamak hassasiyet) |
| `double` | Kesirli Sayı | 8 Byte | ±5.0 x 10^-324 ile ±1.7 x 10^308 (~15 basamak hassasiyet) |
| `decimal` | Kesirli (Finansal)| 16 Byte | ±1.0 x 10^-28 ile ±7.9 x 10^28 (~28 basamak hassasiyet) |
| `char` | Karakter | 2 Byte | Tüm Unicode karakterleri (U+0000 ile U+FFFF) |
| `bool` | Mantıksal | ~1 Byte | `true` veya `false` |
| `string` | Metin | Değişken| Karakter dizileri (Referans Tipi) |
| `var` | Tür Çıkarımı | Değişken| Derleyici tarafından türü belirlenir |

### Ek Notlar
* `float` ve `decimal` kullanımında değer sonuna suffix (`f`, `m`) eklenir:
  - float: `3.14f`
  - decimal: `19.99m`

* Bir değişkene bir değer atandıktan sonra eğer değer sonradan değiştirilirse son değer geçerli olur.
```csharp
int sayi = 10;
sayi = 20; // sayi artık 20 değerine sahiptir.
```

* `const` anahtar kelimesi ile bir değişkene o an değer atanmalıdır ve daha sonradan değiştirilemez. Ve buna ek olarak bir yazılım standartı olarak `const` ifadeler `UPPER_SNAKE_CASE` ile tanımlanır.
```csharp
const double PI = 3.14159;
```

* Aynı türdeki birden fazla değişkene aynı anda değer atanabilir:
```csharp
int x, y, z;
x = y = z = 10; 
```

### Sabitler (Constants)

Programın çalışma süresi boyunca değerleri asla değiştirilemeyen ve değiştirilmesi teklif dahi edilemeyen yapılardır. Kodun okunabilirliğini artırmak ve sihirli sayıları (magic numbers) engellemek için kullanılırlar. C#'ta sabitler iki anahtar kelime ile yönetilir:

#### 1. Compile-Time Constants (`const`)
Değerleri daha kod derlenirken (compile-time) belirlenen sabitlerdir. 
* **Zorunlu İlk Değer:** Tanımlandığı satırda değeri atanmalıdır. Sonradan değer atanamaz.
* **Statik Davranış:** Örtük olarak (implicitly) `static`tir. Nesne oluşturmadan doğrudan sınıf adı üzerinden erişilir (Başına ayrıca `static` yazılması hata verir).
* **İsimlendirme Standardı:** Yazılım standartı olarak `UPPER_SNAKE_CASE` ile tanımlanırlar.
* **Kısıtlama:** Sadece ilkel tipler (`int`, `string`, `double`, `bool` vb.) `const` olabilir.

```csharp
const double PI = 3.14159;
const string API_KEY = "XYZ123";