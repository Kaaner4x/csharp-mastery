using System.Diagnostics;
using AsynchronousProgramming.Services;

namespace AsynchronousProgramming;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== C# Mastery: 14 - Asynchronous Programming ===");
        var weatherService = new WeatherService();
        var cities = new List<string> { "London", "New York", "Tokyo", "Paris", "Berlin" };
        var stopwatch = new Stopwatch();

        // 1. Kötü Pratik: Seri Bekleme (Sequential)
        Console.WriteLine("\n--- Senkron Bekleme (Yanlış Yaklaşım Bağımsız Veriler İçin) ---");
        stopwatch.Start();
        foreach (var city in cities)
        {
            var result = await weatherService.GetWeatherAsync(city);
            Console.WriteLine($"[Seri] {result}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Seri işlem süresi: {stopwatch.ElapsedMilliseconds} ms\n");

        // 2. İyi Pratik: Eşzamanlı (Concurrent) Çalıştırma
        Console.WriteLine("--- Eşzamanlı Çalıştırma (Task.WhenAll) ---");
        stopwatch.Restart();
        
        // Önce sadece Task'leri (işleri) oluşturuyoruz, henüz await etmiyoruz.
        var tasks = cities.Select(city => weatherService.GetWeatherAsync(city)).ToList();
        
        // Tüm görevlerin aynı anda çalışıp bitmesini bekliyoruz.
        var results = await Task.WhenAll(tasks);
        
        foreach (var result in results)
        {
            Console.WriteLine($"[Paralel] {result}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Paralel işlem süresi: {stopwatch.ElapsedMilliseconds} ms (Görüldüğü gibi çok daha hızlı!)\n");

        // 3. IAsyncEnumerable ve await foreach
        Console.WriteLine("--- IAsyncEnumerable (Veri Akışı / Streaming) ---");
        // İstersek CancellationTokenSource ile işlemi iptal edebiliriz
        using var cts = new CancellationTokenSource();
        
        // await foreach ile veriler geldikçe (yield return yapıldıkça) ekrana basılır. 
        // Tüm listenin oluşması beklenmez, anında tepki verilir.
        await foreach (var data in weatherService.GetWeatherStreamAsync(cts.Token))
        {
            Console.WriteLine($"[Stream] Alındı: {data}");
        }

        Console.WriteLine("\nİşlemler tamamlandı.");
    }
}
