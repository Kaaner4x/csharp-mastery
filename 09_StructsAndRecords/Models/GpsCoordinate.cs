namespace CSharp.Mastery.StructsAndRecords.Models;

// readonly struct guarantees immutability, great for performance/memory
public readonly struct GpsCoordinate
{
    public double Latitude { get; }
    public double Longitude { get; }

    public GpsCoordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString() => $"{Latitude}, {Longitude}";
}
