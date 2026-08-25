namespace AsynchronousProgramming.Models;

public class WeatherData
{
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public string Condition { get; set; } = string.Empty;
    
    public override string ToString()
    {
        return $"{City}: {Temperature}°C, {Condition}";
    }
}
