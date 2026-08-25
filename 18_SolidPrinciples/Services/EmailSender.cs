using System;

namespace _18_SolidPrinciples.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"[EmailSender] Sending email to {to}: {message}");
        }
    }
}
