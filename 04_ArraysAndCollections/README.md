# C# Mastery: Diziler ve Koleksiyonlar (Arrays and Collections)

Verilerin bellekte ardışık ya da dinamik olarak tutulması, kurumsal projelerin performansını doğrudan etkiler. Bu modülde statik dizilerden, dinamik listelere; özel amaçlı koleksiyonlardan yeni nesil yüksek performanslı hafıza yönetimi tiplerine (`Span<T>` ve `Memory<T>`) uzanan geniş bir yelpazeyi inceleyeceğiz.

## Teorik Altyapı

### 1. Diziler (Arrays)
- Boyutları oluşturulurken belirtilen ve sonradan değiştirilemeyen yapılardır.
- Bellekte ardışık (contiguous) alan kaplarlar, bu yüzden erişimleri çok hızlıdır.
- `int[] numbers = new int[5];`

### 2. Generic Koleksiyonlar (System.Collections.Generic)
- **List<T>:** Boyutu dinamik olarak değişebilen dizilerdir. Arka planda bir dizi kullanır; kapasite dolduğunda yeni, daha büyük bir dizi oluşturup elemanları oraya taşır.
- **Dictionary<TKey, TValue>:** Key-Value (Anahtar-Değer) çifti mantığıyla çalışır. Hash table altyapısını kullanır, bu sayede eleman arama (`O(1)`) çok hızlıdır.
- **HashSet<T>:** Benzersiz (unique) elemanları tutmak için kullanılır. Arama hızı çok yüksektir.
- **Queue<T>:** FIFO (First In First Out - İlk giren ilk çıkar) mantığıyla çalışır. Mesaj kuyrukları için idealdir.
- **Stack<T>:** LIFO (Last In First Out - Son giren ilk çıkar) mantığıyla çalışır. Geri al (Undo) işlemleri için idealdir.

### 3. Yüksek Performans Tipleri (Span<T> ve Memory<T>)
C# 7.2 ile hayatımıza giren bu tipler, dizilerin veya bellek bloklarının **kopyalanmadan** (sıfır tahsis - zero allocation) bir kısmının alınıp işlenmesini sağlar.
- **Span<T>:** `ref struct` olduğu için sadece **Stack** üzerinde barınabilir. Asenkron (async/await) metotlarda kullanılamaz.
- **Memory<T>:** `Span<T>`'nin Heap üzerinde barınabilen ve asenkron operasyonlarda kullanılabilen versiyonudur.

## Mülakat Soruları ve Cevapları

**Soru 1: Array ile List<T> arasındaki temel fark nedir? Hangi durumda hangisi tercih edilmelidir?**
**Cevap:** Array'in boyutu sabittir, List'in ise dinamiktir. Eğer çalışacağımız veri kümesinin boyutu baştan tam olarak belliyse (örneğin haftanın günleri), Array kullanmak bellek açısından daha verimlidir. Sürekli eleman eklenip çıkarılacak bir yapı varsa List<T> tercih edilmelidir.

**Soru 2: Dictionary yapısının arama hızı neden çok yüksektir?**
**Cevap:** Çünkü elemanları eklerken Key değerinin bir Hash kodunu üretir ve bellekte o index'e yerleştirir. Aradığımızda da doğrudan Hash algoritmasıyla bellek adresine (bucket) gittiği için karmaşıklık genelde O(1)'dir (Yani anında bulur).

**Soru 3: Span<T> kullanmanın performansa katkısı nedir?**
**Cevap:** Büyük bir dizinin veya string'in (örneğin bir dosyanın içeriği) bir kısmını işlemek istediğimizde normalde `Substring` veya yeni dizi oluşturarak veriyi kopyalamamız gerekir. Bu da Heap'te çöp (garbage) yaratır. Span<T> ise veriyi kopyalamadan, sadece orijinal verinin ilgili bölümünü işaret eden (slice) bir yapı sunar. Bu sayede bellek tahsisi yapılmaz ve GC üzerinde yük oluşturulmaz.

## Gerçek Hayat Senaryosu: Gelişmiş Envanter Yönetimi (Inventory Management)
Bir depo/envanter sisteminde:
- Ürünleri hızlıca ismine göre aramak için `Dictionary`.
- Kategori etiketlerini benzersiz tutmak için `HashSet`.
- Gelen yeni ürün kayıtlarını sırayla işlemek için `Queue`.
- Son yapılan işlemleri geri almak (Undo) için `Stack`.
- String parçalama operasyonlarında performans sağlamak için `Span<T>` kullanacağız.
