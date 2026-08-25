using CSharp.Mastery.ObjectOrientedProgramming.Models;
using CSharp.Mastery.ObjectOrientedProgramming.Services;

namespace CSharp.Mastery.ObjectOrientedProgramming;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Rent a Car System ===");

        var rentalService = new RentalService();

        // Using C# 12 Primary Constructors
        var vehicle1 = new Vehicle("Toyota", "Corolla", 2022, 500m);
        var vehicle2 = new Vehicle("Ford", "Mustang", 2023, 1200m);

        rentalService.AddToFleet(vehicle1);
        rentalService.AddToFleet(vehicle2);

        var customer = new Customer("Ali", "Veli", "DL123456");

        Console.WriteLine("\nAvailable Vehicles:");
        foreach (var v in rentalService.GetAvailableVehicles())
        {
            Console.WriteLine(v);
        }

        Console.WriteLine("\nAttempting to rent Toyota Corolla for 3 days...");
        rentalService.ProcessRental(customer, vehicle1, 3);

        Console.WriteLine("\nAttempting to rent Toyota Corolla AGAIN...");
        rentalService.ProcessRental(customer, vehicle1, 2);

        Console.WriteLine("\nReturning Toyota Corolla...");
        rentalService.ProcessReturn(vehicle1);
    }
}
