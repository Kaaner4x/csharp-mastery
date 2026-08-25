# C# 12 ve C# 13 Yeni Özellikleri

C# dili her yeni versiyonda daha temiz kod yazmayı (clean code) sağlayan ve performansı artıran (performance-oriented) özelliklerle güncellenmektedir. Bu modülde C# 12 ve C# 13 ile gelen önemli sentaks yeniliklerine odaklanacağız.

## 1. Teorik Arka Plan

### Collection Expressions (C# 12)
Listeleri, dizileri ve diğer koleksiyonları oluşturmanın daha kısa, birleşik ve okunabilir bir yolu eklenmiştir. Eski `new List<int> { 1, 2, 3 }` sentaksı yerine `[1, 2, 3]` kullanılabilir. Spread operatörü (`..`) ile birden fazla koleksiyon kolayca birleştirilebilir.

### Primary Constructors (C# 12)
Artık class'lar ve struct'lar için doğrudan sınıf tanımının yanında constructor (kurucu metot) tanımlanabilir. Daha önce `record`'lar için geçerli olan bu özellik, standart sınıflara da getirilerek boilerplate (tekrarlayan) kodları azaltmıştır (Özellikle Dependency Injection senaryolarında).

### `ref readonly` Parametreleri (C# 12)
`in` parametresine benzer olarak, değere referansla (reference) ama sadece okunabilir (readonly) erişim sağlayan bir yapıdır. Performans kritik uygulamalarda, struct (yapı) kopyalamalarını önlemek için kullanılırken, API tasarımını daha güvenli hale getirir.

### Interceptors (C# 12 - Experimental / Source Generator Özelliği)
Özellikle AOT (Ahead-of-Time) derlemede ve Source Generators kullanımında, derleme aşamasında (compile-time) bir metot çağrısının hedefini başka bir metoda yönlendirmeye izin veren ileri düzey bir özelliktir. 

## 2. Gerçek Hayat Senaryosu

Senaryomuzda `Customer` modeli, tekrarlayan property tanımlamalarından kaçınmak için **Primary Constructor** ile oluşturulmuştur.
`OrderProcessor` servisinde ise **Collection Expressions** kullanılarak birden fazla ürün listesi tek bir sepette spread operatörü (`..`) ile birleştirilmektedir. Ayrıca sipariş özeti gösterilirken performans avantajı için büyük değer tipleri **`ref readonly`** olarak fonksiyona geçilmektedir.

## 3. Mülakat Soruları

1. **Primary Constructor'ın avantajı nedir? Property tanımlamak zorunlu mudur?**
   - Boilerplate (tekrarlayan) constructor kodunu, private field atamalarını kısaltır. Gelen parametreler doğrudan field gibi kullanılabilir ancak otomatik public Property yaratmaz (Record'lardan farkı budur). Public erişim için manuel property ataması gereklidir.
2. **Collection Expression'da `..` (Spread operatörü) ne işe yarar?**
   - Mevcut bir veya daha fazla koleksiyonu, yeni tanımlanan koleksiyonun içine yayarak/genişleterek (unpacking) birleştirmeye yarar. `var combined = [..list1, ..list2];`
3. **`ref readonly` ve `in` parametre modifiers arasındaki fark nedir?**
   - İkisi de kopyalama maliyetini düşürüp salt okunur referans geçirir. Farkları, API tüketicisinin niyetini belirtmesindedir. `in` kullanırken değişken geçerken modifier belirtmek zorunlu değilken, `ref readonly` kullanırken (C# 12'de) uyarıları yönetmek açısından farklı derleyici kuralları (warning/error behaviors) devreye girer.
