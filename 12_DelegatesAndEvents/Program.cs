using DelegatesAndEvents.Models;
using DelegatesAndEvents.Services;
using DelegatesAndEvents.Events;

namespace DelegatesAndEvents;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== C# Mastery: 12 - Delegates & Events ===");

        var video = new Video { Title = "C# Mastery Course", Format = "MP4", DurationInSeconds = 120 };
        
        var videoEncoder = new VideoEncoder(); // Publisher
        var mailService = new MailService();   // Subscriber 1
        var smsService = new SmsService();     // Subscriber 2

        // Event Abonelikleri (Subscription)
        videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
        videoEncoder.VideoEncoded += smsService.OnVideoEncoded;
        
        // Anonim metot / lambda expression ile abonelik örneği
        videoEncoder.VideoEncodingProgress += (source, args) => 
        {
            Console.WriteLine($"[ProgressBar] İlerleme: %{args.ProgressPercentage}");
        };

        // Metodu tetikliyoruz. İçeride eventler tetiklenecek ve abonelere haber gidecek.
        videoEncoder.Encode(video);

        // Memory Leak önlemi: Abone olunan eventlerden iş bitince çıkmak best practice'tir.
        videoEncoder.VideoEncoded -= mailService.OnVideoEncoded;
        videoEncoder.VideoEncoded -= smsService.OnVideoEncoded;


        Console.WriteLine("\n--- Action, Func, Predicate Örnekleri ---");

        // Action: Parametre alabilir ama değer döndürmez (void)
        Action<string> printLog = message => Console.WriteLine($"[LOG]: {message}");
        printLog("Sistem başarıyla başlatıldı.");

        // Func: Parametre alabilir ve HER ZAMAN değer döndürür. Son parametre dönüş tipidir.
        // Func<int, int, string> -> 2 int parametre alır, 1 string döndürür.
        Func<int, int, int> calculateArea = (width, height) => width * height;
        Console.WriteLine($"[Func] Dikdörtgen Alanı: {calculateArea(10, 5)}");

        // Predicate: Sadece bool döndüren ve tek parametre alan Func türevidir.
        Predicate<Video> isLongVideo = v => v.DurationInSeconds > 60;
        Console.WriteLine($"[Predicate] Video uzun mu? {isLongVideo(video)}");
        
        // Func versiyonu: Func<Video, bool> = v => v.DurationInSeconds > 60;
    }
}
