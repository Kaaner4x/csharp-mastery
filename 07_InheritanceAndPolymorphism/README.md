# Modül 7: Kalıtım ve Çok Biçimlilik (Inheritance & Polymorphism)

## Temel Kavramlar

### Kalıtım (Inheritance)
Kalıtım, bir sınıfın (türetilmiş/derived sınıf) başka bir sınıfın (temel/base sınıf) özelliklerini (alanlar, özellikler, metotlar) miras almasıdır. Kod tekrarını önler ve "IS-A" (dır/dir) ilişkisi kurar. (Örn: Manager IS-A Employee).

### Çok Biçimlilik (Polymorphism)
Çok biçimlilik, aynı isimdeki metodun farklı nesneler için farklı davranışlar sergilemesidir. İki çeşidi vardır:
1. **Compile-time (Static) Polymorphism:** Metot aşırı yükleme (Method Overloading).
2. **Run-time (Dynamic) Polymorphism:** Metot ezme (Method Overriding).

## Önemli Anahtar Kelimeler (Keywords)

- **`virtual`:** Temel sınıfta (base class), türetilmiş sınıflar tarafından değiştirilebilecek (override edilebilecek) metotları işaretler.
- **`override`:** Türetilmiş sınıfta, temel sınıftaki `virtual` veya `abstract` bir metodu ezmek (değiştirmek) için kullanılır.
- **`abstract`:** Hem sınıflar hem de metotlar için kullanılır. `abstract` sınıf doğrudan örneklenemez (`new` ile nesnesi oluşturulamaz). `abstract` metotların gövdesi yoktur ve türetilmiş sınıflar tarafından **ezilmesi zorunludur**.
- **`sealed`:** Bir sınıfın başka sınıflar tarafından miras alınmasını veya bir metodun daha fazla ezilmesini engeller.
- **`base`:** Temel sınıfın üyelerine veya kurucu metotlarına (constructor chaining) erişmek için kullanılır.

## Constructor Chaining (Kurucu Zincirleme)

Türetilmiş bir sınıfın kurucusu çağrıldığında, önce temel sınıfın kurucusu çalışır. `base(...)` anahtar kelimesi ile temel sınıfa gerekli parametreler aktarılır.

## Bellek Yönetimi ve Virtual Method Table (VTable)

Polymorphism run-time'da (çalışma zamanında) gerçekleştiğinde, CLR hangi metodun çağrılacağını bilmek için **VTable (Virtual Method Table)** kullanır.
* Her sınıfın bellekte bir metot tablosu (Method Table) vardır.
* `virtual` metot çağrılarında, nesnenin *gerçek* tipine (runtime tipine) bakılır ve VTable üzerinden doğru bellek adresindeki metot çalıştırılır. Bu işlem, normal (non-virtual) metot çağrılarına göre ufak bir performans maliyeti getirir (indirection).

## Sık Sorulan Mülakat Soruları

1. **Abstract sınıf ile Interface arasındaki fark nedir?**
   *Cevap:* Abstract sınıf kod (state ve gövdeli metot) içerebilir, interface (C# 8 öncesi) sadece imza içerir. Bir sınıf sadece tek bir abstract sınıftan miras alabilirken, birden fazla interface'i implement edebilir.
2. **`sealed` anahtar kelimesi ne işe yarar? Neden kullanırız?**
   *Cevap:* Kalıtımı engeller. Güvenlik, tasarım kısıtlamaları veya JIT optimizasyonu (virtual çağrıların devirtualization'ı) amacıyla kullanılır.
3. **`new` ile metot gizleme (Method Hiding) ve `override` arasındaki fark nedir?**
   *Cevap:* `override` polimorfik davranış sağlar (referans tipi base olsa bile instance tipi neyse o metot çalışır). `new` ise polimorfizmi kırar; derleme zamanı referans tipine (compile-time type) göre karar verilir.

## Gerçek Hayat Senaryosu: Şirket Çalışan Hiyerarşisi

Bu projede bir maaş hesaplama sistemi kurgulanmıştır:
- `Employee` (Çalışan) abstract (soyut) bir sınıftır.
- `Manager` (Yönetici) ve `Developer` (Geliştirici) bu sınıftan miras alır.
- `CalculateSalary` metodu abstract'tır ve her rolde farklı implemente edilir (Polymorphism).
- `Manager` sınıfı `sealed` yapılarak kalıtım sonlandırılmıştır.
- Constructor Chaining ile `Id` ve `Name` gibi ortak özellikler base sınıfa iletilmiştir.
