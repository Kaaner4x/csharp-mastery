using DelegatesAndEvents.Events;

namespace DelegatesAndEvents.Services;

public class SmsService
{
    public void OnVideoEncoded(object? source, VideoEventArgs e)
    {
        Console.WriteLine($"[SmsService] SMS Gönderildi: '{e.Video.Title}' sisteme yüklendi.");
    }
}
