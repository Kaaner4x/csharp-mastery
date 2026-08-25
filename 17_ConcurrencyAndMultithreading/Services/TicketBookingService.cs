using System;
using System.Collections.Concurrent;
using System.Threading;
using _17_ConcurrencyAndMultithreading.Models;

namespace _17_ConcurrencyAndMultithreading.Services
{
    public class TicketBookingService
    {
        private int _availableTickets;
        
        // Lock için kullanılacak private, readonly obje
        private readonly object _bookingLock = new object();
        
        // Başarılı rezervasyonları tutan thread-safe collection
        private readonly ConcurrentBag<Ticket> _bookedTickets = new ConcurrentBag<Ticket>();

        public TicketBookingService(int totalTickets)
        {
            _availableTickets = totalTickets;
        }

        public void BookTicket(int userId)
        {
            // Thread'lerin yoğun olarak çakışmasını simüle etmek için küçük bir gecikme
            Thread.Sleep(10);

            // Eğer kilit (lock) kullanmazsak, iki thread aynı anda _availableTickets > 0 
            // kontrolünü geçip bilet sayısını eksiye düşürebilir (Race Condition).
            lock (_bookingLock)
            {
                if (_availableTickets > 0)
                {
                    _availableTickets--;
                    
                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        BookedAt = DateTime.UtcNow
                    };
                    
                    _bookedTickets.Add(ticket);
                    Console.WriteLine($"User {userId} successfully booked a ticket. Tickets left: {_availableTickets}");
                }
            }
        }

        public int GetSuccessfulBookingCount()
        {
            return _bookedTickets.Count;
        }

        public int GetRemainingTickets()
        {
            return _availableTickets;
        }
    }
}
