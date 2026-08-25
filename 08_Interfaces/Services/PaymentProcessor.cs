using CSharp.Mastery.Interfaces.Interfaces;

namespace CSharp.Mastery.Interfaces.Services;

public class PaymentProcessor
{
    // Dependency Inversion Principle: Depend on abstractions, not concretions.
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void Checkout(decimal amount)
    {
        Console.WriteLine($"\n--- Starting Checkout using {_paymentGateway.GetGatewayName()} ---");
        
        bool result = _paymentGateway.ProcessPayment(amount, "USD");
        
        if(result)
            Console.WriteLine("Checkout completed successfully.");
        else
            Console.WriteLine("Checkout failed.");
    }
}
