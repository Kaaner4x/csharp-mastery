using System;

namespace NullableType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Türkçe karakter desteği

            Console.WriteLine("========================================");
            Console.WriteLine("    C# BOŞ DEĞER ALABİLEN TİPLER (NULLABLE)    ");
            Console.WriteLine("========================================\n");

            // 1. Nullable Value Types (Boş Değer Alabilen Değer Tipleri)
            Console.WriteLine("--- 1. Nullable Value Types ---");
            int? optionalAge = null;
            
            Console.WriteLine($"optionalAge HasValue: {optionalAge.HasValue}");
            Console.WriteLine($"optionalAge GetValueOrDefault(): {optionalAge.GetValueOrDefault()}");
            Console.WriteLine($"optionalAge GetValueOrDefault(18) (Özel Varsayılan): {optionalAge.GetValueOrDefault(18)}");

            // Değer atandıktan sonra durum:
            optionalAge = 25;
            Console.WriteLine("\nDeğer atandıktan sonra (optionalAge = 25):");
            Console.WriteLine($"optionalAge HasValue: {optionalAge.HasValue}");
            if (optionalAge.HasValue)
            {
                // .Value'ya ancak HasValue true ise güvenli bir şekilde erişebiliriz
                Console.WriteLine($"optionalAge Value: {optionalAge.Value}");
            }

            // Null durumunda .Value çağrılırsa ne olur?
            optionalAge = null;
            try
            {
                Console.WriteLine("\noptionalAge null iken .Value okunmaya çalışılıyor...");
#pragma warning disable CS8629 // Kasıtlı olarak null.Value testi yapılıyor
                int ageValue = optionalAge.Value; // Bu satır hata fırlatır!
#pragma warning restore CS8629
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Hata Yakalandı: {ex.Message}\n");
            }

            // 2. Null Operatörleri
            Console.WriteLine("--- 2. Null Operatörleri ---");

            // A. Null-Coalescing Operatörü (??)
            int? score = null;
            int finalScore = score ?? 50; // score null ise 50, değilse kendi değerini kullanır
            Console.WriteLine($"score ?? 50 sonucu: {finalScore}");

            score = 85;
            finalScore = score ?? 50;
            Console.WriteLine($"score 85 iken score ?? 50 sonucu: {finalScore}");

            // B. Null-Coalescing Assignment Operatörü (??=)
            int? dbConnectionTimeout = null;
            dbConnectionTimeout ??= 30; // null olduğu için 30 atanır
            Console.WriteLine($"dbConnectionTimeout ??= 30 sonrası: {dbConnectionTimeout}");
            
            dbConnectionTimeout ??= 60; // zaten 30 (null değil), atama yapılmaz
            Console.WriteLine($"dbConnectionTimeout ??= 60 sonrası: {dbConnectionTimeout}");

            // C. Null-Conditional Operatörü (?.) ve (?.[])
            string? username = null;
            // username?.Length ifadesi NullReferenceException fırlatmaz, doğrudan null döndürür
            int? nameLength = username?.Length;
            Console.WriteLine($"username?.Length sonucu: {(nameLength == null ? "null" : nameLength.ToString())}");

            username = "Antigravity";
            nameLength = username?.Length;
            Console.WriteLine($"username '{username}' iken username?.Length sonucu: {nameLength}");

            // Dizi/Koleksiyon ile Null-Conditional (?.[])
            int[]? scores = null;
            int? firstScore = scores?[0]; // Dizi null olduğu için ilkEleman da null döner, hata vermez
            Console.WriteLine($"scores?[0] sonucu: {(firstScore == null ? "null" : firstScore.ToString())}\n");

            // 3. Nullable Reference Types (Boş Değer Alabilen Referans Tipleri)
            Console.WriteLine("--- 3. Nullable Reference Types (C# 8.0+) ---");
            // csproj dosyasında <Nullable>enable</Nullable> tanımlı olduğundan:
            
            string regularText = "Merhaba"; 
            // regularText = null; // Bu satır derleyici uyarısına (Warning) sebep olur.
            
            string? nullableText = null; // Soru işareti ile derleyiciye null olabileceğini söylüyoruz (Uyarı vermez)
            Console.WriteLine($"regularText (Non-nullable): {regularText}");
            Console.WriteLine($"nullableText (Nullable): {(nullableText ?? "Şu an null")}");

            // Null-forgiving operator (!)
            // Derleyiciye "Bu değerin null olmadığını biliyorum, beni uyarma" demek için kullanılır.
            string definitelyNotNull = nullableText!; 
            Console.WriteLine();

            // 4. Pratik Örnek: Kullanıcıdan İsteğe Bağlı Veri Girişi
            Console.WriteLine("--- 4. Pratik Örnek: Opsiyonel Girdi Yönetimi ---");
            Console.Write("Lütfen favori sayınızı giriniz (Boş geçmek için Enter'a basın): ");
            string? userInput = Console.ReadLine();

            int? favoriteNumber = null;
            if (int.TryParse(userInput, out int tempNumber))
            {
                favoriteNumber = tempNumber;
            }

            // Sonucu null durumuna göre ekrana yazdıralım
            if (favoriteNumber.HasValue)
            {
                Console.WriteLine($"Harika! Favori sayınız: {favoriteNumber.Value}");
            }
            else
            {
                Console.WriteLine("Favori sayı belirtmediniz. Varsayılan sayı olarak 7 seçildi.");
            }

            Console.WriteLine("\nProgramı kapatmak için herhangi bir tuşa basın...");
            Console.ReadKey(true);
        }
    }
}
