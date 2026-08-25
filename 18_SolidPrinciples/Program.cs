using System;
using _18_SolidPrinciples.Services;
using _18_SolidPrinciples.Models;

namespace _18_SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLID Principles Demo - User Registration\n");

            // Dependency Injection (Manuel olarak)
            IEmailSender emailSender = new EmailSender();
            IUserService userService = new UserService(emailSender);

            var newUser = new User 
            { 
                Id = 1, 
                Username = "emir_dev", 
                Email = "emir@example.com" 
            };

            userService.RegisterUser(newUser);

            Console.WriteLine("\nRegistration process completed following SOLID principles.");
        }
    }
}
