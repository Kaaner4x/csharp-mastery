using System;

namespace _19_DesignPatterns.Services
{
    public sealed class Logger
    {
        // Thread-safe Singleton uygulaması için Lazy<T> kullanımı idealdir
        private static readonly Lazy<Logger> _lazyInstance = new Lazy<Logger>(() => new Logger());

        public static Logger Instance => _lazyInstance.Value;

        private Logger()
        {
            // Sınıfın sadece kendi içinden (private) oluşturulabilmesini sağlıyoruz.
            Console.WriteLine("[Logger] Singleton instance created.");
        }

        public void Log(string message)
        {
            // Gerçek senaryoda bu metot bir dosyaya ya da veri tabanına yazar.
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
