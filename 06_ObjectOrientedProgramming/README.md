# Modül 6: Nesne Yönelimli Programlama (Object Oriented Programming - OOP)

## Temel Kavramlar

Nesne Yönelimli Programlama (OOP), yazılımı "nesneler" (objects) etrafında modelleyen bir programlama paradigmasıdır. C# tamamen nesne yönelimli bir dildir ve OOP'nin dört temel prensibini destekler: 
1. **Encapsulation (Kapsülleme)**
2. **Inheritance (Kalıtım)**
3. **Polymorphism (Çok Biçimlilik)**
4. **Abstraction (Soyutlama)**

Bu modülde özellikle Sınıflar (Classes), Nesneler (Objects) ve **Kapsülleme (Encapsulation)** üzerine odaklanacağız.

## Encapsulation (Kapsülleme) ve Property Doğrulaması

Kapsülleme, nesnenin iç durumunu (state) dış dünyadan gizleme ve bu duruma erişimi kontrollü bir şekilde (Property'ler veya Metotlar aracılığıyla) sağlama prensibidir. C#'ta bu işlem `private` field'lar (alanlar) ve `public` property'ler (özellikler) kullanılarak yapılır. Bu sayede verinin bütünlüğü korunur (Property Validation).

Örneğin; bir aracın üretim yılı 2000'den küçük olamaz kuralını property'nin `set` bloğunda kontrol edebiliriz.

## C# 12 Primary Constructors (Birincil Kurucular)

C# 12 ile birlikte sınıflar (class) ve yapılar (struct) için birincil kurucular (primary constructors) tanıtıldı. Bu özellik, sınıf tanımlaması sırasında parametreleri doğrudan sınıf isminin yanında belirtmemizi sağlar. Bu parametreler, sınıfın tüm gövdesinde erişilebilir hale gelir.

```csharp
public class Vehicle(string brand, string model) 
{
    public string Brand { get; } = brand;
    public string Model { get; } = model;
}
```

## Bellek Yönetimi (Memory Management)

Sınıflar (Class) referans tiplerdir (Reference Types) ve **Heap** bellekte tutulurlar. 
* Yeni bir nesne oluşturulduğunda (`new` anahtar kelimesi ile), Heap üzerinde o nesne için yer ayrılır.
* Stack üzerinde ise sadece bu nesnenin Heap'teki bellek adresini (referansını) tutan bir işaretçi (pointer) bulunur.
* Heap üzerindeki bir nesne, Object Header (Nesne Başlığı) ve Method Table (Metot Tablosu) işaretçisine sahiptir.
* Referansı kalmayan nesneler, **Garbage Collector (Çöp Toplayıcı)** tarafından otomatik olarak temizlenir.

## Sık Sorulan Mülakat Soruları

1. **Encapsulation neden önemlidir?**
   *Cevap:* Veri gizliliğini ve güvenliğini sağlar. Sınıfın iç işleyişini dış dünyadan soyutlar, yanlış veri atanmasını engeller (örneğin negatif yaş değeri girilmesi).
2. **C# 12 Primary Constructors'ın geleneksel constructor'lardan farkı nedir?**
   *Cevap:* Kod tekrarını (boilerplate) azaltır. Constructor parametreleri doğrudan sınıf tanımında verilir ve class içindeki tüm üyelere scope dahilinde açılır. Field atamaları basitleşir.
3. **Class (Sınıf) ve Object (Nesne) arasındaki fark nedir?**
   *Cevap:* Sınıf bir şablondur (blueprint). Nesne ise bu şablondan bellekte (Heap) oluşturulmuş somut bir örnektir (instance).

## Gerçek Hayat Senaryosu: Rent a Car Sistemi

Bu modülde yer alan projede:
- `Vehicle` sınıfında **Primary Constructors** kullanılmıştır.
- Kapsülleme ile araç `Year` ve `DailyPrice` değerleri doğrulanmıştır (Validation).
- Durum (state) değişikliği sadece sınıfın içindeki metotlarla (`Rent()`, `Return()`) sınırlandırılmıştır (Anemic Domain Model'den kaçınarak zengin model tasarlanmıştır).
