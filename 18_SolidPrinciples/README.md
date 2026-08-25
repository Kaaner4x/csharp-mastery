# C# SOLID Prensipleri

SOLID prensipleri, yazılımın sürdürülebilir, okunabilir ve genişletilebilir (maintainable & extensible) olmasını sağlayan nesne yönelimli programlama (OOP) ilkeleridir. Bu modülde kötü yazılmış bir "User Registration" (Kullanıcı Kayıt) servisini adım adım SOLID prensiplerine uygun hale getireceğiz.

## 1. SOLID Prensibi Nedir?

- **S (Single Responsibility Principle - Tek Sorumluluk Prensibi):** Bir sınıfın değişmek için sadece bir nedeni olmalıdır. (Yani tek bir iş yapmalıdır).
- **O (Open/Closed Principle - Açık/Kapalı Prensibi):** Sınıflar, gelişime açık, değişime kapalı olmalıdır. (Yeni özellik eklerken mevcut kodu değiştirmeden, extend edebilmeliyiz).
- **L (Liskov Substitution Principle - Liskov Yerine Geçme Prensibi):** Alt sınıflar, üst sınıflarının yerine kullanılabilir olmalıdır ve beklenmedik bir davranış göstermemelidir.
- **I (Interface Segregation Principle - Arayüz Ayrımı Prensibi):** Kullanılmayan metotları içeren büyük (şişman) arayüzler yerine, spesifik ve küçük arayüzler oluşturulmalıdır.
- **D (Dependency Inversion Principle - Bağımlılıkların Tersine Çevrilmesi Prensibi):** Yüksek seviyeli modüller, düşük seviyeli modüllere bağımlı olmamalıdır; ikisi de soyutlamalara (interface/abstract class) bağımlı olmalıdır.

## 2. Gerçek Hayat Senaryosu

Senaryomuzda `UserService` sınıfı, kullanıcı kaydı yapıyor, veritabanına log yazıyor ve aynı sınıf içinde doğrudan `EmailSender` (somut) sınıfını "new" anahtar kelimesiyle oluşturup email gönderiyor. Bu durum:
- **SRP İhlali:** `UserService` hem kayıt, hem email gönderimi hem de loglama işlemlerini biliyor.
- **DIP İhlali:** `UserService`, `EmailSender` isimli somut bir sınıfa sıkı sıkıya bağlı (tightly coupled). 
- **OCP İhlali:** Yarın SMS göndermek istersek `UserService` içine yeni kod yazmak (mevcut kodu değiştirmek) zorunda kalacağız.

Refactoring sonrasında:
Email gönderimi `IEmailSender` arayüzüne taşınarak dışarıdan (Dependency Injection ile) enjekte edilecek. `UserService` sadece kullanıcı kaydından sorumlu olacak.

## 3. Mülakat Soruları

1. **Dependency Inversion ile Dependency Injection arasındaki fark nedir?**
   - Dependency Inversion (DIP) bir prensiptir (soyutlamaya bağımlı olma kuralı). Dependency Injection (DI) ise bu prensibi uygulamak için kullanılan bir tasarım desenidir (bağımlılığı dışarıdan verme yöntemi).
2. **Liskov Substitution Principle'a aykırı bir örnek verebilir misiniz?**
   - Klasik "Kuş" ve "Penguen" örneği. `Kus` sınıfında `Uc()` metodu varsa ve `Penguen` bu sınıftan kalıtım alıyorsa, `Penguen` sınıfında `Uc()` metodu çağrıldığında `NotImplementedException` fırlatılır. Bu Liskov prensibine aykırıdır; alt sınıf, üst sınıfın davranışı bozmaktadır. Çözüm, `IUcabilenler` gibi ayrı bir interface oluşturmaktır.
3. **Sınıfı değişime kapatıp gelişime nasıl açarsınız (Open/Closed)?**
   - Kalıtım (Inheritance), Interface'ler veya Strategy Design Pattern gibi yapılar kullanarak. Yeni bir durum eklendiğinde `if/else` veya `switch-case` bloklarına dokunmak yerine, interface'i implemente eden yeni bir sınıf oluştururuz.
