using CSharp.Mastery.Interfaces.Services;
using CSharp.Mastery.Interfaces.Interfaces;

namespace CSharp.Mastery.Interfaces;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Multiple Payment Gateways Scenario ===");

        // Using Stripe
        IPaymentGateway stripeGateway = new StripePaymentGateway();
        var processorStripe = new PaymentProcessor(stripeGateway);
        processorStripe.Checkout(150.50m);

        // Using PayPal
        IPaymentGateway paypalGateway = new PayPalPaymentGateway();
        var processorPayPal = new PaymentProcessor(paypalGateway);
        processorPayPal.Checkout(89.99m);
    }
}
