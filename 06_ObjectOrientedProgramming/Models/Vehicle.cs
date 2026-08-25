namespace CSharp.Mastery.ObjectOrientedProgramming.Models;

// C# 12 Primary Constructor example
public class Vehicle(string brand, string model, int year, decimal dailyPrice)
{
    // Properties using Primary Constructor parameters
    public string Brand { get; } = brand;
    public string Model { get; } = model;
    
    // Encapsulation and Property Validation
    private int _year = year;
    public int Year
    {
        get => _year;
        set
        {
            if (value < 2000 || value > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid vehicle year.");
            _year = value;
        }
    }

    private decimal _dailyPrice = dailyPrice;
    public decimal DailyPrice
    {
        get => _dailyPrice;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Daily price must be greater than zero.");
            _dailyPrice = value;
        }
    }

    public bool IsAvailable { get; private set; } = true;

    // Methods encapsulating state changes
    public void Rent()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Vehicle is already rented.");
        IsAvailable = false;
    }

    public void Return()
    {
        IsAvailable = true;
    }

    public override string ToString() => $"{Brand} {Model} ({Year}) - {DailyPrice:C}/day";
}
