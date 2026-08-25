using CSharp.Mastery.Interfaces.Interfaces;

namespace CSharp.Mastery.Interfaces.Services;

// Multiple Interface Inheritance
public class StripePaymentGateway : IPaymentGateway, ILoggable
{
    public bool ProcessPayment(decimal amount, string currency)
    {
        Console.WriteLine($"[Stripe] Processing payment of {amount} {currency}...");
        // Simulated logic
        bool success = amount > 0; 
        
        LogTransaction(success ? "Payment Successful" : "Payment Failed");
        return success;
    }

    // Overriding the default interface method
    public string GetGatewayName() => "Stripe Gateway";

    public void LogTransaction(string message)
    {
        Console.WriteLine($"[Stripe Log]: {message}");
    }
}
