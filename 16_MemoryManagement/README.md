# C# Memory Management & Garbage Collection

Bu modülde C# dilinde bellek yönetimi (Memory Management), Garbage Collection (GC) mekanizması, `IDisposable` arayüzü ve `using` bloklarının derinlemesine nasıl çalıştığını inceleyeceğiz. 

## 1. Teorik Arka Plan ve GC Mekanizması

.NET ortamında bellek iki ana bölüme ayrılır:
- **Stack (Yığın):** Değer tiplerinin (Value Types) ve metot çağrı zincirlerinin tutulduğu hızlı bellek alanıdır. LIFO (Last In First Out) mantığıyla çalışır, scope (kapsam) bittiğinde otomatik temizlenir.
- **Heap (Öbek):** Referans tiplerinin (Reference Types) tutulduğu daha büyük bellek alanıdır. GC tarafından yönetilir.

### Garbage Collector (GC)
GC, heap'te kullanılmayan (referansı kalmamış) nesneleri tespit eder ve bellekten siler. Bunu 3 jenerasyon (Generation) halinde yapar:
- **Gen 0:** Kısa ömürlü nesneler (örneğin metot içi geçici değişkenler). En sık temizlenen jenerasyondur.
- **Gen 1:** Gen 0'daki temizlikten kurtulan (hala referansı olan) nesneler buraya taşınır.
- **Gen 2:** Gen 1'den de kurtulan uzun ömürlü (örneğin static nesneler, önbelleğe alınmış veriler) nesnelerin tutulduğu yerdir. En az sıklıkla temizlenir.

## 2. IDisposable ve Unmanaged Resources

GC, sadece .NET tarafından yönetilen (managed) nesneleri temizler. Dosya akışları (File Streams), veritabanı bağlantıları (DB Connections), ağ soketleri (Network Sockets) gibi "Unmanaged" (yönetilmeyen) kaynaklar GC tarafından otomatik kapatılamaz.
Bu tür kaynakları serbest bırakmak için `IDisposable` arayüzü kullanılır ve `Dispose` metodu çağrılır.

### Using Bloğu
`using` anahtar kelimesi, `try-finally` bloğunun syntactic sugar (sözdizimsel şeker) halidir. Scope sonunda otomatik olarak `Dispose` metodunu çağırarak bellek/kaynak sızıntılarını (memory leaks) önler.

## 3. Gerçek Hayat Senaryosu

Senaryomuzda ağır bir dosya okuma işlemi (`LargeFileReader`) gerçekleştiriyoruz. Büyük boyutlu log dosyalarını okuyup satır satır işliyoruz. Burada `StreamReader` unmanaged bir kaynak kullandığı için `IDisposable` arayüzünü implemente ediyoruz.

## 4. Mülakat Soruları

1. **Stack ve Heap arasındaki fark nedir?**
   - Stack hızlı, sınırlı boyutlu, LIFO mantığıyla çalışan ve değer tiplerini tutan alandır. Heap ise referans tiplerini tutan, dinamik boyutlu ve GC tarafından yönetilen alandır.
2. **Garbage Collector ne zaman çalışır? Jenerasyonlar (Generations) nelerdir?**
   - Gen 0 belleği dolduğunda, sistem belleği azaldığında veya `GC.Collect()` (önerilmez) manuel çağrıldığında çalışır. Jenerasyonlar Gen 0, Gen 1 ve Gen 2'dir.
3. **`IDisposable` neden kullanılır? Finalizer (`~ClassName`) ile farkı nedir?**
   - Unmanaged kaynakları (dosya, DB bağlantısı) temizlemek için kullanılır. `Dispose` developer tarafından çağrılır (veya using ile). Finalizer ise GC tarafından nesne yok edilirken çağrılır (zamanı belirsizdir).
4. **Memory Leak (Bellek sızıntısı) .NET'te nasıl oluşur?**
   - Event handler'ların (`+=`) temizlenmemesi (`-=`), static koleksiyonların sürekli büyümesi, unmanaged kaynakların `Dispose` edilmemesi başlıca sebeplerdir.

## 5. Bellek Kullanımı İpuçları
- Gereksiz nesne üretiminden kaçının.
- Büyük string birleştirme işlemleri için `StringBuilder` kullanın.
- Sadece gerçekten unmanaged kaynak kullanıyorsanız veya IDisposable başka sınıfları sarmalıyorsanız (wrap) IDisposable implemente edin.
