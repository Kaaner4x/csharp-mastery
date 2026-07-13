namespace TypeCasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Türkçe karakter desteği için

            Console.WriteLine(" C# TIP DÖNÜŞÜMLERİ VE VERİ GİRİŞİ ");

            // 1. Bilinçsiz (Implicit) Dönüşüm
            Console.WriteLine("--- 1. Bilinçsiz (Implicit) Dönüşüm ---");
            int intValue = 123;
            double doubleValue = intValue; // Otomatik dönüşüm (int'ten double'a)
            Console.WriteLine($"int değer: {intValue} -> double değer: {doubleValue}");

            char charValue = 'x';
            int asciiValue = charValue; // Otomatik dönüşüm (char'dan int'e - ASCII karşılığı)
            Console.WriteLine($"char değer: '{charValue}' -> int (ASCII) değer: {asciiValue}\n");

            // 2. Bilinçli (Explicit) Dönüşüm
            Console.WriteLine("--- 2. Bilinçli (Explicit) Dönüşüm ---");
            double pi = 3.14159;
            int roundedPi = (int)pi; // Cast operatörü (veri kaybı: ondalık kısım atılır)
            Console.WriteLine($"double değer: {pi} -> int değer (cast ile): {roundedPi}");

            // Taşma (Overflow) ve checked/unchecked davranışı
            int largeInt = 258;
            byte byteValue = (byte)largeInt; // byte en fazla 255 alabilir, taşma olur.
            Console.WriteLine($"int değer: {largeInt} -> byte değer (cast ile - taşmalı): {byteValue}");

            try
            {
                Console.WriteLine("checked bloğu çalıştırılıyor...");
                checked
                {
                    // Bu satır OverflowException fırlatacaktır
                    byte overflowByte = (byte)largeInt;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("checked bloğu sayesinde taşma algılandı ve hata yakalandı!\n");
            }

            // 3. Convert Sınıfı ile Dönüşüm
            Console.WriteLine("--- 3. Convert Sınıfı ---");
            string numberString = "456";
            int convertedNumber = Convert.ToInt32(numberString);
            Console.WriteLine($"Convert.ToInt32(\"{numberString}\") sonucu: {convertedNumber}");

            // Convert null değerleri varsayılana çevirir, hata fırlatmaz
            string? nullString = null;
            int nullConverted = Convert.ToInt32(nullString);
            Console.WriteLine($"Convert.ToInt32(null) sonucu (varsayılan): {nullConverted}\n");

            // 4. Parse ve TryParse Metotları
            Console.WriteLine("--- 4. Parse ve TryParse Metotları ---");
            string validText = "789";
            string invalidText = "99abc";

            // Parse metodu (Başarılı)
            int parsedValue = int.Parse(validText);
            Console.WriteLine($"int.Parse(\"{validText}\") sonucu: {parsedValue}");

            // TryParse metodu (Güvenli Dönüşüm)
            if (int.TryParse(invalidText, out int result))
            {
                Console.WriteLine($"int.TryParse(\"{invalidText}\") başarılı! Sonuç: {result}");
            }
            else
            {
                Console.WriteLine($"int.TryParse(\"{invalidText}\") başarısız! Hata fırlatılmadı, güvenle kontrol edildi.");
            }
            Console.WriteLine();

            // 5. Kullanıcıdan Veri Alma (Input) ve Dönüştürme
            Console.WriteLine("--- 5. Kullanıcıdan Veri Alma (Input) ---");

            // Console.ReadLine()
            Console.Write("Lütfen adınızı giriniz: ");
            string? name = Console.ReadLine();
            Console.WriteLine($"Merhaba {name}!");

            // Sayısal Giriş Alma ve Dönüştürme (TryParse ile)
            int birthYear = 0;
            bool isValidYear = false;

            while (!isValidYear)
            {
                Console.Write("Lütfen doğum yılınızı giriniz (YYYY): ");
                string? birthYearInput = Console.ReadLine();

                isValidYear = int.TryParse(birthYearInput, out birthYear);

                if (!isValidYear)
                {
                    Console.WriteLine("Geçersiz bir yıl girdiniz. Lütfen sadece rakam girin.");
                }
            }

            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;
            Console.WriteLine($"Harika! Şu anki yaşınız: {age}\n");

            // Console.Read() - Tek bir karakterin ASCII kodunu okur
            Console.WriteLine("Lütfen bir karaktere basıp Enter'a tıklayın (Console.Read için):");
            int charAscii = Console.Read();
            // Enter tuşundan kalan newline karakterlerini temizlemek için Console.ReadLine çağırıyoruz
            Console.ReadLine();
            Console.WriteLine($"Bastığınız karakterin ASCII kodu: {charAscii}, Karakter karşılığı: {(char)charAscii}\n");

            // Console.ReadKey() - Tek tuş basımını algılar
            Console.WriteLine("Uygulamayı kapatmak için herhangi bir tuşa basın...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.WriteLine($"Bastığınız tuş: {keyInfo.Key} (Modifiers: {keyInfo.Modifiers})");
            Console.WriteLine("Program sonlandırıldı.");
        }
    }
}
