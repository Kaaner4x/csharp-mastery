using DelegatesAndEvents.Events;

namespace DelegatesAndEvents.Services;

public class MailService
{
    // Event handler metodu, delegate'in (EventHandler<VideoEventArgs>) imzasına uymalıdır.
    public void OnVideoEncoded(object? source, VideoEventArgs e)
    {
        Console.WriteLine($"[MailService] Bilgi Maili Gönderildi: '{e.Video.Title}' hazır.");
    }
}
