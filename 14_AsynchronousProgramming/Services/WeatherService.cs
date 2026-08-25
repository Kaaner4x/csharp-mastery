using AsynchronousProgramming.Models;
using System.Runtime.CompilerServices;

namespace AsynchronousProgramming.Services;

public class WeatherService
{
    private readonly Random _random = new();

    /// <summary>
    /// Simüle edilmiş, 1 saniye süren dış API çağrısı
    /// </summary>
    public async Task<WeatherData> GetWeatherAsync(string city)
    {
        // ConfigureAwait(false) kütüphane kodlarında deadlock'ları önlemek için best practice'dir.
        await Task.Delay(1000).ConfigureAwait(false); 

        return new WeatherData
        {
            City = city,
            Temperature = Math.Round(_random.NextDouble() * 40 - 5, 1),
            Condition = _random.Next(0, 2) == 0 ? "Güneşli" : "Yağmurlu"
        };
    }

    /// <summary>
    /// C# 8.0 ile gelen IAsyncEnumerable kullanımı.
    /// Veriler hazır oldukça (streaming) tüketiciye gönderilir, hepsi bitene kadar beklenmez.
    /// </summary>
    public async IAsyncEnumerable<WeatherData> GetWeatherStreamAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string[] cities = { "Istanbul", "Ankara", "Izmir", "Bursa", "Antalya" };

        foreach (var city in cities)
        {
            // İptal isteği gelmiş mi kontrol et
            cancellationToken.ThrowIfCancellationRequested();

            // Veriyi getir (simüle edilmiş I/O)
            await Task.Delay(500, cancellationToken).ConfigureAwait(false);
            
            yield return new WeatherData
            {
                City = city,
                Temperature = Math.Round(_random.NextDouble() * 40 - 5, 1),
                Condition = "Parçalı Bulutlu"
            };
        }
    }
}
