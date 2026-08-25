# Bölüm 13: LINQ (Language Integrated Query)

## 1. Teorik Altyapı ve Çalışma Mantığı

**LINQ (Language Integrated Query)**, C# 3.0 ile dile entegre edilen, farklı veri kaynaklarından (Collections, SQL, XML, Entity Framework vb.) standart, tip güvenli (type-safe) ve okunabilir bir sözdizimi ile veri sorgulamamızı sağlayan güçlü bir teknolojidir.

### LINQ Sağlayıcıları (Providers)
- **LINQ to Objects:** `IEnumerable<T>` uygulayan koleksiyonlar (List, Array vb.) üzerinde çalışır.
- **LINQ to Entities:** Entity Framework üzerinden veritabanı sorguları için kullanılır. `IQueryable<T>` arayüzü üzerinden SQL sorgusuna çevrilir.
- **LINQ to XML:** XML dokümanları üzerinde sorgulama yapar.

### Deferred Execution (Ertelenmiş Çalıştırma)
LINQ'nun en önemli özelliklerinden biri **Ertelenmiş Çalıştırma**dır. Bir LINQ sorgusu yazıldığında hemen çalıştırılmaz. Sorgu sadece ne yapılacağını tanımlar. Gerçek hesaplama (iterasyon) sorgu sonucuna ulaşıldığında yapılır.

**Ertelenmiş Çalıştırmayı Tetikleyen İşlemler (Immediate Execution):**
- `ToList()`, `ToArray()`, `ToDictionary()`
- `Count()`, `Max()`, `Average()` vb. (Aggregation metotları)
- `First()`, `Single()`, `Any()`, `All()` (Element metotları)
- `foreach` döngüsü ile sorgunun üzerinde gezinmek

## 2. Bellek Yönetimi ve Performans
- `IEnumerable` (LINQ to Objects) üzerinde `Where`, `Select` gibi işlemler yaparken yield return yapısı kullanılır. Bu sayede tüm veriler aynı anda belleğe yüklenmez, iterasyon sırasında talep edildikçe belleğe çekilir (Streaming / Lazy Evaluation).
- Ancak `ToList()` çağrıldığında o anki sonuçların hepsi hesaplanıp yeni bir liste olarak belleğe alınır. Gereksiz `ToList()` çağrıları bellek tüketimini (GC allocation) artırır ve performansı düşürür.
- `IQueryable` kullanırken sorgu SQL'e çevrileceği için, filtrelemeler veritabanında yapılır. Ancak yanlışlıkla `IEnumerable`'a cast edilip (`AsEnumerable()` veya `ToList()`) sonra `Where` atılırsa, veritabanındaki tüm kayıtlar belleğe çekilir ve filtreleme RAM'de yapılır. Bu çok ciddi performans sorunlarına yol açar.

## 3. Extension Methods (Genişletme Metotları) Sözdizimi vs Query Sözdizimi
LINQ iki farklı yazım stiline sahiptir:
1. **Method Syntax (Fluent API):** `users.Where(u => u.Age > 18).OrderBy(u => u.Name)` -> Sektörde çok daha yaygındır, zincirleme metot yapısıyla çalışır.
2. **Query Syntax:** `from u in users where u.Age > 18 orderby u.Name select u` -> SQL'e çok benzer, özellikle karmaşık `join` işlemlerinde okunabilirliği artırabilir.

## 4. Mülakat Soruları ve Cevapları

**Soru 1: IEnumerable ve IQueryable arasındaki fark nedir?**
**Cevap:** `IEnumerable` bellek içindeki (in-memory) koleksiyonları temsil eder ve sorguları çalıştıran kod (filtremeler vb.) bellekte işlenir. `IQueryable` ise veritabanı gibi dış sistemlerle iletişim için tasarlanmıştır; sorgular Expression Tree olarak tutulur ve hedefe (SQL) gönderilmeden önce çalıştırılabilir SQL cümleciğine dönüştürülür. Filtrelemeler SQL tarafında yapılır, böylece sadece ihtiyaç duyulan veriler belleğe alınır.

**Soru 2: Ertelenmiş Çalıştırma (Deferred Execution) nedir?**
**Cevap:** LINQ sorgularının tanımlandığı anda değil, sadece sonuçların gerçekten istendiği anda (`ToList`, `Count`, `foreach` kullanımı vb.) çalıştırılmasıdır. Bu, birden fazla filtreleme adımının tek seferde işlenmesini sağlayarak performansı artırır.

**Soru 3: Select ve SelectMany arasındaki fark nedir?**
**Cevap:** `Select` her elemanı tek bir elemana dönüştürür (1'e 1 mapping). `SelectMany` ise iç içe geçmiş koleksiyonları düzleştirerek (flattening) tek bir koleksiyon haline getirir (1'e çok mapping).

## 5. Gerçek Hayat Senaryosu: Şirket Veritabanı Simülasyonu
Bu modülde; Departmanlar, Çalışanlar ve Projelerden oluşan bir in-memory şirket veritabanı modeli üzerinden Join, GroupBy, SelectMany ve Aggregate işlemlerini inceleyeceğiz.
