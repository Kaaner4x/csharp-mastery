using CSharp.Mastery.ObjectOrientedProgramming.Models;

namespace CSharp.Mastery.ObjectOrientedProgramming.Services;

public class RentalService
{
    private readonly List<Vehicle> _fleet = new();

    public void AddToFleet(Vehicle vehicle)
    {
        _fleet.Add(vehicle);
    }

    public void ProcessRental(Customer customer, Vehicle vehicle, int days)
    {
        Console.WriteLine($"Processing rental for {customer.FullName}...");
        
        try
        {
            vehicle.Rent();
            decimal totalCost = vehicle.DailyPrice * days;
            Console.WriteLine($"Successfully rented {vehicle.Brand} {vehicle.Model} for {days} days. Total cost: {totalCost:C}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Rental failed: {ex.Message}");
        }
    }

    public void ProcessReturn(Vehicle vehicle)
    {
        vehicle.Return();
        Console.WriteLine($"{vehicle.Brand} {vehicle.Model} has been returned and is available.");
    }
    
    public IEnumerable<Vehicle> GetAvailableVehicles() => _fleet.Where(v => v.IsAvailable);
}
