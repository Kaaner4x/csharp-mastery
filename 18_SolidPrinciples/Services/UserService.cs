using System;
using _18_SolidPrinciples.Models;

namespace _18_SolidPrinciples.Services
{
    // Single Responsibility Principle (SRP) & Dependency Inversion Principle (DIP) applied
    public class UserService : IUserService
    {
        private readonly IEmailSender _emailSender;

        // Constructor Injection
        public UserService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void RegisterUser(User user)
        {
            // 1. Veritabanı kayıt işlemleri (SRP gereği burada sadece User iş mantığı var)
            Console.WriteLine($"[UserService] User {user.Username} saved to database.");

            // 2. Email gönderimi (DIP gereği soyut arayüze bağımlıyız)
            _emailSender.SendEmail(user.Email, "Welcome to our platform!");
            
            // Eğer yeni bir bildirim yöntemi (SMS vs.) eklenirse, 
            // INotificationService gibi bir yapı tasarlanarak OCP sağlanabilir.
        }
    }
}
