namespace _18_SolidPrinciples.Services
{
    public interface IEmailSender
    {
        void SendEmail(string to, string message);
    }
}
