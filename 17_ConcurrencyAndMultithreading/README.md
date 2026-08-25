# C# Concurrency & Multithreading

Bu modülde, çoklu iş parçacığı (Multithreading), Eşzamanlılık (Concurrency), Race Condition (Yarış Durumu) gibi problemleri ve bu problemleri çözmek için kullanılan `lock`, `Mutex`, `SemaphoreSlim` gibi senkronizasyon araçlarını inceleyeceğiz.

## 1. Teorik Arka Plan

- **Thread:** Bir sürecin (process) içinde çalışan en küçük işlem birimidir.
- **Multithreading:** Aynı anda birden fazla thread'in çalışarak işlemci çekirdeklerini efektif kullanmasıdır.
- **Concurrency (Eşzamanlılık):** Birden fazla işlemin aynı zaman diliminde (aynı anda olmak zorunda değil, zaman paylaşımlı olarak) ilerlemesidir.
- **Race Condition:** İki veya daha fazla thread'in aynı paylaşılan kaynağa (değişken, dosya vs.) aynı anda erişip değiştirmeye çalışması sonucunda verinin tutarsız hale gelmesidir.

### Senkronizasyon Araçları
1. **lock (Monitor):** Bir thread bir kod bloğuna girdiğinde, diğer thread'lerin o bloğa girmesini engeller. En yaygın ve basit yöntemdir.
2. **Mutex:** `lock` ile benzerdir, ancak farklı process'ler (uygulamalar) arasında da senkronizasyon sağlayabilir (Cross-process). Performans maliyeti daha yüksektir.
3. **Semaphore / SemaphoreSlim:** Aynı anda birden fazla (belirtilen sayıda) thread'in bir kaynağa erişmesine izin verir. `SemaphoreSlim`, aynı process içinde çalışan daha hafif versiyonudur.
4. **Concurrent Collections:** `ConcurrentDictionary`, `ConcurrentBag` gibi sınıflar kendi içlerinde thread-safe olarak tasarlandıkları için manuel `lock` kullanımını azaltır.

## 2. Gerçek Hayat Senaryosu

Senaryomuz bir **Bilet Satış Sistemi (Ticket Booking System)**. Sınırlı sayıda biletin olduğu bir konsere, aynı anda yüzlerce kullanıcı (thread) bilet almaya çalışmaktadır. Eğer senkronizasyon yapmazsak, "Race Condition" nedeniyle var olandan fazla bilet satılabilir (Overselling). Bu durumu `lock` veya diğer thread-safe yapılarla çözeceğiz.

## 3. Mülakat Soruları

1. **Process ve Thread arasındaki fark nedir?**
   - Process, kendine ait bellek alanı olan bağımsız bir programdır. Thread ise process içinde çalışan iş birimleridir ve aynı process'in belleğini paylaşırlar.
2. **Race Condition nedir, nasıl önlenir?**
   - Birden fazla thread'in paylaşılan kaynağa eşzamanlı ve kontrolsüz erişmesiyle oluşur. `lock`, `Mutex`, `Interlocked` sınıfı gibi yapılarla önlenir.
3. **`lock` anahtar kelimesi kullanırken neden `public` veya `this` nesnesi yerine özel bir `private readonly object` kilit nesnesi tercih edilir?**
   - `this` veya `public` bir nesne kullanmak, uygulamanın başka bir yerinde de o nesneye `lock` konulursa **Deadlock** (Ölümcül Kilitlenme) ihtimalini artırır.
4. **`async/await` ile `Thread` (Multithreading) aynı şey midir?**
   - Hayır. `Thread` yeni bir iş parçacığı oluşturur. `async/await` ise bir işlemi asenkron yapar, thread'i bloke etmek (block) yerine serbest bırakır. İkisi farklı kavramlardır ama birlikte kullanılabilirler.
