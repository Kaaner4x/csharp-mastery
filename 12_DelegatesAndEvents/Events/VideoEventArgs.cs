using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Events;

/// <summary>
/// Event fırlatıldığında dinleyicilere (subscribers) taşınacak veriyi (payload) temsil eder.
/// </summary>
public class VideoEventArgs : EventArgs
{
    public Video Video { get; set; } = null!;
    public int ProgressPercentage { get; set; }
}
