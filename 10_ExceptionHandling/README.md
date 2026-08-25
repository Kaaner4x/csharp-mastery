# Modül 10: İstisna Yönetimi (Exception Handling)

## Temel Kavramlar

Yazılımın çalışması sırasında ortaya çıkan olağan dışı, beklenmeyen durumlara **Exception (İstisna)** denir. C#'ta bu durumları yönetmek için `try`, `catch`, `finally` ve `throw` blokları kullanılır.

- **`try`:** Hataya neden olabilecek riskli kodların yazıldığı bloktur.
- **`catch`:** `try` bloğu içinde fırlatılan bir istisnayı yakalayan ve ilgili kurtarma/loglama işleminin yapıldığı bloktur.
- **`finally`:** Hata olsa da olmasa da **kesinlikle** çalışan bloktur. Genellikle veritabanı bağlantılarını kapatmak, dosya akışlarını serbest bırakmak (resource cleanup) için kullanılır.
- **`throw`:** Bilinçli olarak bir istisna fırlatmak (üretmek) için kullanılır. `throw;` şeklinde tek başına kullanıldığında (catch içinde), mevcut exception'ın stack trace'ini (izini) bozmadan bir üst katmana iletir (re-throw).

## Özel Hatalar (Custom Exceptions)

Sisteme veya uygulamanın iş kurallarına (Domain Logic) özgü hata durumları yaratmak istediğimizde `Exception` sınıfından miras alan özel sınıflar oluştururuz.
Örneğin: `UserNotFoundException`, `InsufficientBalanceException` vb.
Bu, hataların türlerine göre farklı davranışlar (catch blokları) sergilememize olanak tanır.

## Global Exception Handler Pattern (Merkezi Hata Yönetimi)

Modern uygulamalarda (özellikle ASP.NET Core gibi web API'lerinde), `try-catch` bloklarını uygulamanın her yerine saçmak yerine, hataları tek bir merkezde (Middleware veya Filter aracılığıyla) yakalamak (Global Exception Handling) tercih edilir. Bu yaklaşım kod tekrarını azaltır ve standartlaştırılmış hata yanıtları döndürülmesini sağlar.

## Bellek Yönetimi ve Performans

- Hata fırlatmak maliyetli bir işlemdir (Performans açısından pahalıdır). Çünkü .NET Runtime, o anki yürütme bağlamının (Call Stack) bir anlık görüntüsünü (Stack Trace) alır.
- Bu yüzden istisnalar sadece "istisnai" durumlar için kullanılmalıdır. İş akışını (Control Flow) yönlendirmek (örneğin doğrulama kurallarında) için hata fırlatmak yerine (exception-driven logic), geriye dönüş tipleri (Result Pattern vs.) tercih edilmelidir.

## Sık Sorulan Mülakat Soruları

1. **`throw ex;` ile `throw;` arasındaki fark nedir?**
   *Cevap:* `throw ex;` hatayı fırlattığı satırı başlangıç kabul ederek Stack Trace'i (Çağrı yığını izini) sıfırlar (orijinal hatanın nerede olduğunu kaybedersiniz). `throw;` ise orijinal stack trace'i koruyarak hatayı bir üst katmana iletir. Daima `throw;` tercih edilmelidir.
2. **Birden fazla catch bloğu varsa sıralama nasıl olmalıdır?**
   *Cevap:* En spesifik olan exception tipinden (örneğin `FileNotFoundException`), en genel olan exception tipine (örneğin `Exception`) doğru sıralanmalıdır. Aksi takdirde derleme hatası alırsınız.
3. **`finally` bloğu çalışmayabilir mi?**
   *Cevap:* Normal şartlarda her zaman çalışır. Ancak `StackOverflowException`, uygulamanın aniden sonlandırılması (Environment.FailFast) veya işletim sisteminin süreci (process) öldürmesi durumlarında çalışmaz.

## Gerçek Hayat Senaryosu: Dış API Entegrasyonu

Bu modüldeki projede, uzak bir sunucudan (External API) veri çeken bir servis simüle edilmiştir. 
- Servisin fırlattığı özel hatalar (`ApiException`, `ResourceNotFoundException`) ve sistem hataları (`ArgumentNullException`, `DivideByZeroException`), merkezi bir hata yakalayıcı (`GlobalExceptionHandler`) üzerinden standart bir yapıya sokularak terminale yazdırılmıştır. 
- Bu mimari, ASP.NET Core uygulamalarındaki Exception Middleware mantığının konsol uygulaması üzerindeki izdüşümüdür.
