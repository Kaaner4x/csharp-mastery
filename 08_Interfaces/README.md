# Modül 8: Arayüzler (Interfaces)

## Temel Kavramlar

Interface (Arayüz), bir sınıfın veya yapının (struct) hangi özellikleri ve metotları içermesi gerektiğini tanımlayan bir sözleşmedir (contract). 
- Sınıflar, arayüzü `implement` ettiklerinde (uyguladıklarında), arayüzdeki tüm imzalara uygun kodları barındırmak zorundadırlar.
- Arayüzler sayesinde sistemdeki bileşenler birbirine sıkı sıkıya bağlı (tightly coupled) olmaz, gevşek bağlı (loosely coupled) olur.

## Dependency Inversion (Bağımlılığı Tersine Çevirme) Prensibi (SOLID'in D'si)

Yüksek seviyeli modüller, düşük seviyeli modüllere bağlı olmamalıdır; her ikisi de soyutlamalara (abstractions - örneğin Interface'lere) bağlı olmalıdır.
- Senaryomuzda `PaymentProcessor` sınıfı doğrudan `StripePaymentGateway` sınıfına (somut sınıf) bağlı değildir. Bunun yerine `IPaymentGateway` arayüzüne bağlıdır. Bu sayede sisteme `PayPalPaymentGateway` eklemek `PaymentProcessor` kodunu bozmaz.

## Çoklu Kalıtım (Multiple Inheritance)

C#'ta bir sınıf sadece tek bir sınıftan miras alabilir (Single Class Inheritance). Ancak bir sınıf **birden fazla arayüzü** uygulayabilir (Multiple Interface Implementation).
Örneğin `StripePaymentGateway`, hem `IPaymentGateway` hem de `ILoggable` arayüzlerini aynı anda implement eder.

## C# 8.0 Default Interface Methods (Varsayılan Arayüz Metotları)

C# 8.0 ile birlikte arayüzler içine gövdesi olan metotlar (default implementation) eklenebilir hale geldi.
- **Amaç:** Mevcut bir arayüze yeni bir metot eklendiğinde, bu arayüzü daha önce implement etmiş olan eski sınıfların derlenmesinin bozulmasını (breaking change) engellemektir.
- Senaryomuzda `GetGatewayName()` metodu arayüz seviyesinde tanımlanmıştır. `Stripe` bunu ezerken, `PayPal` varsayılan davranışı kullanır.

## Bellek Yönetimi

Arayüzler referans tipli (Reference Type) davranışı gösterirler. Bir değer tipi (Struct) bir arayüze atandığında (örneğin `IPaymentGateway gateway = myStruct;`), **Boxing (Kutulama)** işlemi gerçekleşir ve veri Heap belleğe taşınır. Sınıflar için arayüz kullanımı doğrudan referans kopyalamadır ve ekstra bellek yükü (boxing) yaratmaz.

## Sık Sorulan Mülakat Soruları

1. **Interface ile Abstract Sınıf arasındaki temel mimari fark nedir?**
   *Cevap:* Interface bir nesnenin "ne yapabildiğini" (CAN-DO) belirtirken, Abstract class nesnenin "ne olduğunu" (IS-A) belirtir.
2. **Dependency Injection (Bağımlılık Enjeksiyonu) Interface'ler olmadan yapılabilir mi?**
   *Cevap:* Evet, somut sınıflar (concrete classes) veya delegate'ler ile de yapılabilir ancak mock'lama, test edilebilirlik ve esneklik (loose coupling) sağlamak için genellikle Interface'ler üzerinden yapılması tercih edilir.
3. **Explicit Interface Implementation (Açık Arayüz Uygulaması) nedir?**
   *Cevap:* İki farklı interface aynı isimde bir metoda sahipse ve bir sınıf her ikisini de uyguluyorsa, hangi metodun kime ait olduğunu belirtmek için `InterfaceAdı.MetotAdı` şeklinde yapılan uygulamadır.

## Gerçek Hayat Senaryosu: Çoklu Ödeme Sistemleri

Bu projede bir e-ticaret uygulamasındaki ödeme altyapısı modellenmiştir. Yeni bir ödeme sağlayıcısı (örn: Iyzico) eklemek istediğimizde tek yapmamız gereken `IPaymentGateway` arayüzünü implement eden yeni bir sınıf yazmaktır. `PaymentProcessor` sınıfına hiç dokunmamıza gerek kalmaz.
