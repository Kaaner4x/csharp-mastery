# C# Mastery: Kontrol Akışları ve Döngüler (Control Flow and Loops)

Bu modülde bir uygulamanın beyni olarak nitelendirebileceğimiz karar ve akış mekanizmalarını (`if-else`, `switch`, `while`, `do-while`, `for`, `foreach`) inceleyeceğiz. Özellikle kurumsal yazılımlarda sıklıkla kullanılan **State Machine (Durum Makinesi)** mantığı ve kullanıcı menüsü iterasyonlarını göreceğiz.

## Teorik Altyapı

### 1. Kontrol İfadeleri (Control Statements)
- **if/else-if/else:** Belirli bir boolean koşul sağlandığında çalışacak kod bloklarını belirler.
- **Ternary Operator (`? :`):** Tek satırlık basit if-else durumları için idealdir. (Örn: `var sonuc = isOk ? "Tamam" : "Hata";`)

### 2. Döngüler (Loops)
- **for:** İterasyon sayısının net olarak bilindiği durumlarda kullanılır.
- **foreach:** `IEnumerable` veya `IEnumerable<T>` arayüzünü uygulayan koleksiyonların elemanları üzerinde gezinmek için kullanılır. Bellek ve performans açısından enumerator mantığıyla çalışır.
- **while:** Koşul doğru (true) olduğu sürece çalışan döngüdür.
- **do-while:** Koşul kontrol edilmeden önce bloğun **en az bir kere** çalışmasını garanti eden döngüdür.

### 3. Atlama İfadeleri (Jump Statements)
- **break:** İçinde bulunduğu döngüyü (veya switch bloğunu) tamamen sonlandırır ve dışarı çıkar.
- **continue:** Döngünün mevcut iterasyonunu atlar ve bir sonraki iterasyona geçer.
- **return:** Bulunduğu metodu sonlandırır ve çağrıldığı yere (varsa bir değer ile) döner.

## Mülakat Soruları ve Cevapları

**Soru 1: `while` ve `do-while` döngüleri arasındaki fark nedir?**
**Cevap:** `while` döngüsünde koşul döngünün başında kontrol edilir; koşul baştan yanlışsa döngü hiç çalışmaz. `do-while` döngüsünde ise koşul döngünün sonunda kontrol edilir, bu da kod bloğunun en az bir kere çalışmasını garanti eder.

**Soru 2: Infinite Loop (Sonsuz Döngü) nedir ve nasıl bilinçli olarak kullanılır?**
**Cevap:** `while(true)` veya `for(;;)` gibi bitiş koşulu her zaman doğru olan döngülerdir. Sunucu dinleme işlemleri, oyun motorları veya ATM tarzı sürekli kullanıcı girdisi bekleyen interaktif menü sistemlerinde (State Machine mantığıyla) bilinçli olarak kullanılır. İşlem bitirilmek istendiğinde `break` veya `return` ile çıkılır.

**Soru 3: `foreach` döngüsünde koleksiyonun bir elemanını döngü içindeyken silebilir misiniz?**
**Cevap:** Hayır. `foreach` döngüsü bir *Enumerator* kullandığından, döngü sırasında koleksiyonun yapısı (eleman ekleme/çıkarma) değiştirilirse `InvalidOperationException` hatası fırlatır. Silme işlemi için tersine çalışan bir `for` döngüsü veya LINQ metodları tercih edilmelidir.

## Gerçek Hayat Senaryosu: ATM Menü ve State Machine Sistemi
Bir ATM yazılımının simülasyonunu yapacağız. Sistem sürekli olarak aktif kalacak (`while(true)` sonsuz döngüsü), kullanıcı girişlerini kontrol edecek (`if-else`, `continue`), menü seçimlerine göre farklı durumlara geçecek (`switch`) ve çıkış komutuyla kapanacaktır (`break`).
