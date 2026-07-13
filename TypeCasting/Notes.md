# Tip Dönüşümleri (Type Casting) ve Kullanıcıdan Veri Alma (Input)

C# programlama dilinde, bir veri tipindeki değişkeni başka bir veri tipine dönüştürme işlemine **Tip Dönüşümü (Type Casting)** denir. C# statik olarak tiplendirilmiş (strongly-typed) bir dil olduğu için, veri tipleri arasındaki uyum ve dönüşümler büyük önem taşır.

Bu belgede hem tip dönüşüm yöntemlerini hem de kullanıcıdan veri alma (Input) işlemlerini ve bu ikisinin nasıl birlikte kullanıldığını inceleyeceğiz.

---

## 1. Tip Dönüşümleri (Type Casting)

C#'ta tip dönüşümleri temelde ikiye ayrılır: **Bilinçsiz (Implicit) Dönüşüm** ve **Bilinçli (Explicit) Dönüşüm**. Ayrıca string dönüşümleri için yardımcı metotlar ve sınıflar kullanılır.

### A. Bilinçsiz Tip Dönüşümü (Implicit Casting)
* Herhangi bir ek operatör veya kod yazmadan, derleyicinin otomatik olarak yaptığı dönüşümlerdir.
* **Kural:** Küçük boyutlu veya daha az kapsayıcı bir veri tipi, daha büyük veya daha geniş kapsayıcı bir veri tipine atanırken otomatik olarak dönüştürülür. Bu işlemde veri kaybı (data loss) veya taşma (overflow) riski yoktur.
* **Dönüşüm Yönü:** `char` -> `int` -> `long` -> `float` -> `double`

**Örnek:**
```csharp
int tamSayi = 9;
double ondalikliSayi = tamSayi; // Otomatik dönüşüm (int -> double)

char karakter = 'A';
int asciiDeger = karakter; // Otomatik dönüşüm (char -> int). Çıktı: 65
```

---

### B. Bilinçli Tip Dönüşümü (Explicit Casting - Cast Operatörü)
* Derleyicinin otomatik olarak yapamadığı, yazılımcının sorumluluk alarak gerçekleştirdiği dönüşümlerdir.
* **Kural:** Büyük veya daha kapsamlı bir veri tipi, daha küçük bir veri tipine dönüştürülürken kullanılır. Parantez içinde hedef tür yazılarak `(hedefTur)` cast operatörü kullanılır.
* **Risk:** Veri kaybı veya taşma yaşanabilir (örneğin `double` bir sayıyı `int` yaparken virgülden sonrası kaybolur; ya da büyük bir sayı daha küçük bir veri tipinin sınırlarını aşarsa hatalı değerler oluşur).

**Örnek:**
```csharp
double ondalik = 9.78;
int tam = (int)ondalik; // Bilinçli dönüşüm. Ondalık kısım atılır. Çıktı: 9

int buyukSayi = 257;
byte kucukSayi = (byte)buyukSayi; // Taşma gerçekleşir! byte max 255 alabilir. Çıktı: 1 (257 - 256)
```

#### `checked` ve `unchecked` Blokları
Bilinçli dönüşümlerde taşma durumunda hata fırlatılmasını (exception) istiyorsak `checked` bloğu kullanırız. Varsayılan davranış `unchecked` gibidir (hata fırlatmaz, taşan değeri döner).
```csharp
checked
{
    int buyuk = 300;
    byte kucuk = (byte)buyuk; // System.OverflowException fırlatır!
}
```

---

### C. Yardımcı Sınıflar ve Metotlar ile Dönüşüm

Metinsel (string) ifadeleri sayısal ifadelere veya farklı tipleri birbirine dönüştürmek için C# özel araçlar sunar.

#### 1. `Convert` Sınıfı
`System` ad alanı altındaki `Convert` sınıfı, hemen hemen tüm temel veri tiplerini birbirine dönüştürmek için statik metotlar sunar. 
* En önemli farkı, `null` değerleri güvenle yönetmesidir. Eğer dönüştürülecek değer `null` ise hata fırlatmak yerine hedef tipin varsayılan değerini (örneğin sayısal tipler için `0`, bool için `false`) döner.
* Örnek metotlar: `Convert.ToInt32()`, `Convert.ToDouble()`, `Convert.ToBoolean()`, `Convert.ToString()` vb.

```csharp
string metin = "123";
int sayi = Convert.ToInt32(metin); // Çıktı: 123

string nullMetin = null;
int varsayilanSayi = Convert.ToInt32(nullMetin); // Hata vermez, çıktı: 0
```

#### 2. `Parse` Metodu
Sadece **string** ifadeleri hedef veri tipine dönüştürmek için kullanılır. Tüm temel veri tiplerinde (int, double, bool vb.) bulunur.
* **Risk:** Eğer string ifade hedef veri tipine uygun değilse (örneğin `"abc"` ifadesini int yapmaya çalışırsak) veya `null` ise `FormatException` veya `ArgumentNullException` hatası fırlatır.

```csharp
string sayiMetni = "456";
int sayi = int.Parse(sayiMetni); // Başarılı, çıktı: 456

string gecersizMetin = "12a";
int hata = int.Parse(gecersizMetin); // FormatException fırlatır!
```

#### 3. `TryParse` Metodu
`Parse` metodunun hata fırlatmayan, güvenli versiyonudur. Dönüşümün başarılı olup olmadığını kontrol etmek için sıklıkla tercih edilir.
* Geriye dönüşümün başarısını belirten bir `bool` (`true`/`false`) değer döndürür.
* Dönüştürülen değer ise `out` anahtar kelimesi ile bir değişkene aktarılır.

```csharp
string girdi = "789";
bool basariliMi = int.TryParse(girdi, out int sonuc);

if (basariliMi)
{
    Console.WriteLine($"Dönüşüm başarılı: {sonuc}");
}
else
{
    Console.WriteLine("Geçersiz format, dönüşüm başarısız.");
}
```

#### 4. `ToString` Metodu
C#'taki tüm nesneler (object) en tepedeki `System.Object` sınıfından türediği için hepsinin `.ToString()` metodu vardır. Herhangi bir değeri doğrudan metne (string) dönüştürmek için kullanılır.

```csharp
int sayi = 100;
string metin = sayi.ToString(); // "100"
```

---

## 2. Kullanıcıdan Veri Alma (Input)

C# Console uygulamalarında kullanıcıdan veri almak için `Console` sınıfının giriş (input) metotları kullanılır.

| Metot | Açıklama | Geri Dönüş Tipi |
| --- | --- | --- |
| `Console.ReadLine()` | Kullanıcı `Enter` tuşuna basana kadar yazdığı tüm satırı okur. | `string?` (boş geçilebilir string) |
| `Console.Read()` | Kullanıcının klavyeden bastığı ilk karakterin **ASCII kodunu** okur. | `int` |
| `Console.ReadKey()` | Kullanıcının bastığı tek bir tuş bilgisini okur. Ekranı bekletmek veya özel tuş kombinasyonlarını yakalamak için idealdir. | `ConsoleKeyInfo` |

### Kullanıcıdan Sayısal Giriş Almak (Input + Casting/Parsing)
`Console.ReadLine()` metodu her zaman **string** bir değer döndürür. Kullanıcıdan sayı alıp matematiksel işlem yapmak istiyorsak, bu string girdiyi uygun veri tipine (int, double vb.) dönüştürmemiz gerekir.

**Gelişmiş Girdi Alma Şablonu:**
```csharp
Console.Write("Lütfen yaşınızı giriniz: ");
string input = Console.ReadLine();

// Güvenli dönüşüm (TryParse)
if (int.TryParse(input, out int yas))
{
    Console.WriteLine($"Gelecek yıl yaşınız: {yas + 1}");
}
else
{
    Console.WriteLine("Hatalı yaş girişi yaptınız!");
}
```
