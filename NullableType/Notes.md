# Boş Değer Alabilen Tipler (Nullable Types)

C# dilinde veri tipleri temelde ikiye ayrılır: **Değer Tipleri (Value Types)** (int, double, bool, struct vb.) ve **Referans Tipleri (Reference Types)** (string, class, array vb.). 

Varsayılan olarak, referans tipleri `null` (boş/tanımsız) değerini alabilirken, değer tipleri her zaman bellekte bir yer kaplar ve `null` değer alamazlar (örneğin bir `int` varsayılan olarak `0` değerini alır, boş olamaz).

Ancak veritabanları veya API'ler gibi dış kaynaklarla çalışırken bazı değerlerin "bilinmeyen" veya "boş" olması gerekir. Bu duruma çözüm olarak C# **Nullable Types (Boş Değer Alabilen Tipler)** yapısını sunar.

---

## 1. Nullable Value Types (Boş Değer Alabilen Değer Tipleri)

Değer tiplerini boş değer alabilir hale getirmek için tip adının sonuna soru işareti (`?`) eklenir veya genel (`generic`) `Nullable<T>` yapısı kullanılır.

*   `int?` (veya `Nullable<int>`)
*   `bool?` (veya `Nullable<bool>`)
*   `double?` (veya `Nullable<double>`)

```csharp
int? yas = null; // Geçerli
bool? ogrenciMi = null; // Geçerli
```

### Önemli Özellikler ve Metotlar

Nullable bir değer tipinin içeriğini güvenle kontrol etmek ve değerine erişmek için şu özellikler kullanılır:

1.  **`HasValue`:** Değişkenin içerisinde bir değer olup olmadığını kontrol eder. Geriye `true` veya `false` döner.
2.  **`Value`:** Değişkenin değerini döndürür. **Önemli:** Eğer değişken `null` ise ve `.Value` çağrılırsa `InvalidOperationException` hatası alınır. Bu yüzden önce `HasValue` kontrol edilmelidir.
3.  **`GetValueOrDefault()`:** Değişken doluysa değerini, boşsa o veri tipinin varsayılan değerini (örn. `int` için `0`, `bool` için `false`) döner. İstenirse parametre olarak alternatif bir varsayılan değer de alabilir: `GetValueOrDefault(5)`.

**Örnek:**
```csharp
int? puan = null;

if (puan.HasValue)
{
    Console.WriteLine($"Puan: {puan.Value}");
}
else
{
    Console.WriteLine("Puan henüz girilmemiş.");
}

// Varsayılan değer yönetimi
int sonPuan = puan.GetValueOrDefault(-1); // puan null olduğu için -1 dönecektir.
```

---

## 2. Null Operatörleri (Null Operators)

C# null değerlerle güvenli bir şekilde çalışmayı kolaylaştırmak için çeşitli operatörler sunar:

### A. Null-Coalescing Operatörü (`??`)
Eğer sol taraftaki ifade `null` ise sağ taraftaki değeri, `null` değilse sol taraftaki değeri döndürür.

```csharp
int? veritabanindanGelenYas = null;
int nihaiYas = veritabanindanGelenYas ?? 18; // Yas null olduğu için 18 atanır.
```

### B. Null-Coalescing Assignment Operatörü (`??=`)
Eğer sol taraftaki değişken `null` ise sağ taraftaki değeri o değişkene atar. Eğer zaten doluysa hiçbir şey yapmaz.

```csharp
int? sayi = null;
sayi ??= 10; // sayi null olduğu için artık 10 oldu.
sayi ??= 20; // sayi dolu (10) olduğu için 20 atanmaz, 10 olarak kalır.
```

### C. Null-Conditional Operatörü (`?.` ve `?[...]`)
Bir nesnenin üyesine veya indeksine erişirken nesnenin `null` olup olmadığını kontrol eder. Eğer nesne `null` ise işlem durdurulur ve doğrudan `null` döner, böylece `NullReferenceException` hatası engellenir.

```csharp
string? metin = null;

// Normalde metin.Length hata verir ama ?. ile vermez, geriye null döner.
int? uzunluk = metin?.Length; 

// Liste veya dizilerde element erişimi için ?[...] kullanılır
int[]? sayilar = null;
int? ilkEleman = sayilar?[0]; // Hata vermez, null döner.
```

---

## 3. Nullable Reference Types (Boş Değer Alabilen Referans Tipleri)

C# 8.0 ile birlikte gelen bu özellik, referans tiplerinin (string, class vb.) yanlışlıkla `null` atanıp `NullReferenceException` hatasına yol açmasını engellemeyi hedefler. Proje dosyasında (csproj) `<Nullable>enable</Nullable>` olarak tanımlanmışsa bu kurallar geçerlidir:

*   **Non-nullable Reference Type:** Varsayılan olarak `string` tipi `null` alamayacağını belirtir. Eğer `null` atanırsa derleyici uyarı (warning) verir.
    ```csharp
    string ad = null; // Derleyici uyarısı: Non-nullable field must contain a non-null value...
    ```
*   **Nullable Reference Type:** Eğer değişkenin `null` alabileceğini kabul ediyorsak tipin sonuna `?` koymalıyız.
    ```csharp
    string? soyad = null; // Uyarı vermez, tamamen yasaldır.
    ```

### Null-Forgiving Operatör (`!`)
Derleyiciye bir değişkenin o satırda kesinlikle `null` olmayacağını taahhüt etmek için değişken adının sonuna ünlem (`!`) konur. Bu operatör derleyicinin verdiği null uyarılarını susturmak için kullanılır.

```csharp
string? isim = "Ahmet";
string kesinIsim = isim!; // Derleyiciye "güven bana, bu null değil" diyoruz.
```
