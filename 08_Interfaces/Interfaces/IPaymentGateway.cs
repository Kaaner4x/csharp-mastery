namespace CSharp.Mastery.Interfaces.Interfaces;

public interface IPaymentGateway
{
    // Method signature
    bool ProcessPayment(decimal amount, string currency);

    // C# 8.0 Default Interface Method
    public string GetGatewayName()
    {
        return "Unknown Gateway";
    }
}
