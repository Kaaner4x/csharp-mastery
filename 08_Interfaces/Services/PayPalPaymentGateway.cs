using CSharp.Mastery.Interfaces.Interfaces;

namespace CSharp.Mastery.Interfaces.Services;

public class PayPalPaymentGateway : IPaymentGateway
{
    public bool ProcessPayment(decimal amount, string currency)
    {
        Console.WriteLine($"[PayPal] Redirecting to PayPal for {amount} {currency}...");
        return true;
    }
    
    // Notice we do NOT override GetGatewayName(). 
    // It will use the default implementation from IPaymentGateway.
}
