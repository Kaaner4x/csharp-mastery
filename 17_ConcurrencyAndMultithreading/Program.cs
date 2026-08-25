using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _17_ConcurrencyAndMultithreading.Services;

namespace _17_ConcurrencyAndMultithreading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ticket Booking System - Concurrency Demo");

            var bookingService = new TicketBookingService(totalTickets: 100);
            
            // Aynı anda bilet almaya çalışan 200 istek (thread) simüle edelim
            int numberOfBookingAttempts = 200;
            var tasks = new List<Task>();

            for (int i = 0; i < numberOfBookingAttempts; i++)
            {
                int userId = i + 1;
                tasks.Add(Task.Run(() => bookingService.BookTicket(userId)));
            }

            // Tüm task'lerin (satın alma denemelerinin) bitmesini bekle
            await Task.WhenAll(tasks);

            Console.WriteLine($"\nBooking session closed.");
            Console.WriteLine($"Total Successful Bookings: {bookingService.GetSuccessfulBookingCount()}");
            Console.WriteLine($"Tickets remaining: {bookingService.GetRemainingTickets()}");
            
            // Eğer senkronizasyon yapılmasaydı, Race Condition yüzünden kalan bilet eksiye düşebilir
            // veya 100 biletten fazla satılabilirdi.
        }
    }
}
