# Bölüm 14: Asynchronous Programming (Asenkron Programlama)

## 1. Teorik Altyapı ve Çalışma Mantığı

C# 5.0 ile gelen `async` ve `await` anahtar kelimeleri, asenkron programlamayı çok daha okunabilir ve yönetilebilir hale getirmiştir. Asenkron programlamanın temel amacı, uzun süren işlemler (G/Ç (I/O) işlemleri, veritabanı sorguları, ağ istekleri vb.) sırasında ana iş parçacığını (thread) bloklamamaktır.

- **CPU-bound vs I/O-bound:** Asenkron programlama genellikle I/O-bound işlemler için idealdir (Ağdan veri indirme). CPU-bound (yoğun matematiksel hesaplama) işlemler için ise çoklu iş parçacığı (multithreading - `Task.Run`) kullanmak daha doğrudur.

### Arka Planda Neler Oluyor? (State Machine)
Derleyici, `async` olarak işaretlenmiş bir metodu gördüğünde, arka planda karmaşık bir `IAsyncStateMachine` (Durum Makinesi) sınıfı üretir. Kod `await` ifadesine geldiğinde, mevcut thread serbest bırakılır ve state machine'in durumu kaydedilir. İşlem tamamlandığında, state machine kaldığı yerden çalışmaya devam eder (genellikle farklı bir ThreadPool thread'i üzerinden).

### Deadlock (Kördüğüm) ve .ConfigureAwait(false)
Eski .NET Framework projelerinde (ASP.NET MVC veya WinForms/WPF), SynchronizationContext adı verilen bir yapı bulunur. Bir UI thread'i veya request thread'i, asenkron bir metodu `.Result` veya `.Wait()` ile senkron olarak beklerse (bloklarsa), asenkron işlem bitip geri dönmek istediğinde SynchronizationContext'i dolu bulur ve **Deadlock** (kördüğüm) oluşur.
**Çözüm:** 
1. Asenkron metotları **asla** `.Result` veya `.Wait()` ile beklemeyin; tüm zincir boyunca `async/await` (async all the way) kullanın.
2. Kütüphane (Library) yazarken, context'e dönme zorunluluğunu kaldırmak için her zaman `await Task...ConfigureAwait(false);` kullanın. (.NET Core / 5+ uygulamalarında SynchronizationContext olmadığı için deadlock riski daha düşüktür ancak kütüphaneler için bu kural hala geçerlidir.)

## 2. Mülakat Soruları ve Cevapları

**Soru 1: `Task.Run` ile I/O işlemlerini (örneğin HttpClient.GetAsync) sarmalamak doğru mudur?**
**Cevap:** Hayır, yanlıştır ("Async over Sync" veya gereksiz thread kullanımı). I/O asenkron işlemleri zaten donanım seviyesinde asenkrondur ve thread tüketmezler. `Task.Run` kullanarak ekstra bir ThreadPool thread'ini gereksiz yere meşgul etmiş olursunuz. Sadece CPU yoğun işlemler için `Task.Run` kullanılmalıdır.

**Soru 2: `async void` neden tehlikelidir? Ne zaman kullanılabilir?**
**Cevap:** `async void` metotlarda fırlatılan exception'lar yakalanamaz (catch edilemez) ve uygulamanın aniden çökmesine neden olur (AppDomain crash). Sadece Event Handler'larda (örn. buton tıklaması `private async void btn_Click...`) kullanılması kabul edilebilirdir. Diğer tüm durumlarda `async Task` kullanılmalıdır.

**Soru 3: `Task.WhenAll` ile `foreach` içinde `await` kullanmak arasındaki fark nedir?**
**Cevap:** `foreach` içinde `await` kullanmak işlemleri seri (sequential) hale getirir; biri bitmeden diğeri başlamaz. `Task.WhenAll` ise gönderilen tüm task'leri paralel/eşzamanlı başlatır ve hepsinin bitmesini aynı anda bekler. Bağımsız ağ isteklerinde `Task.WhenAll` kullanmak süreyi büyük ölçüde kısaltır.

## 3. IAsyncEnumerable (C# 8.0)
`IEnumerable<T>` tüm veriyi belleğe alıp senkron döndürürken, `IAsyncEnumerable<T>` verinin parça parça asenkron olarak (streaming) üretilip tüketilmesini sağlar. Bellek dostudur ve `await foreach` döngüsüyle okunur.

## 4. Gerçek Hayat Senaryosu: Hava Durumu Servisi
Bu senaryoda, bağımsız şehirlerin hava durumu bilgilerini simüle edilmiş bir dış API'den çekeceğiz. Seri çekim ile eşzamanlı çekim (`Task.WhenAll`) arasındaki zaman farkını gözlemleyeceğiz. Ayrıca `IAsyncEnumerable` kullanımını göreceğiz.
