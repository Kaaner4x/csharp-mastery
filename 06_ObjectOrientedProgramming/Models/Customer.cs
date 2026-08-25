namespace CSharp.Mastery.ObjectOrientedProgramming.Models;

public class Customer(string firstName, string lastName, string driverLicenseNumber)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public string DriverLicenseNumber { get; } = driverLicenseNumber;

    public string FullName => $"{FirstName} {LastName}";
}
