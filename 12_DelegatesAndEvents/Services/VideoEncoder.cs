using DelegatesAndEvents.Events;
using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Services;

public class VideoEncoder
{
    // C#'ta modern event tanımlama yaklaşımı EventHandler<TEventArgs> kullanmaktır.
    // Ancak klasik delegate tanımını görmek için önce kendi delegate'imizi yazalım:
    // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
    // public event VideoEncodedEventHandler VideoEncoded;
    
    // Modern Yaklaşım:
    public event EventHandler<VideoEventArgs>? VideoEncodingStarted;
    public event EventHandler<VideoEventArgs>? VideoEncodingProgress;
    public event EventHandler<VideoEventArgs>? VideoEncoded;

    public void Encode(Video video)
    {
        Console.WriteLine($"\n[VideoEncoder] '{video.Title}' için encoding işlemi başlatılıyor...");
        
        // 1. Başlangıç Event'ini tetikle
        OnVideoEncodingStarted(video);

        // Encoding simülasyonu
        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(500); // Gerçek hayatta burada asenkron işlemler olur
            
            // 2. İlerleme Event'ini tetikle
            OnVideoEncodingProgress(video, i * 20);
        }

        Console.WriteLine($"[VideoEncoder] '{video.Title}' encoding işlemi tamamlandı.");
        
        // 3. Bitiş Event'ini tetikle
        OnVideoEncoded(video);
    }

    // Event tetikleyici metotlar genellikle protected virtual tanımlanır, 
    // böylece bu sınıftan türeyen sınıflar event mantığını ezebilir (override).
    protected virtual void OnVideoEncodingStarted(Video video)
    {
        VideoEncodingStarted?.Invoke(this, new VideoEventArgs { Video = video });
    }

    protected virtual void OnVideoEncodingProgress(Video video, int progress)
    {
        VideoEncodingProgress?.Invoke(this, new VideoEventArgs { Video = video, ProgressPercentage = progress });
    }

    protected virtual void OnVideoEncoded(Video video)
    {
        // Null conditional operator (?.) ile event'e abone olan var mı kontrol edilir.
        // Varsa Invoke ile tüm aboneler tetiklenir.
        VideoEncoded?.Invoke(this, new VideoEventArgs { Video = video, ProgressPercentage = 100 });
    }
}
