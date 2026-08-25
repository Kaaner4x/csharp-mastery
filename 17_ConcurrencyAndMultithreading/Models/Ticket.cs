using System;

namespace _17_ConcurrencyAndMultithreading.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime BookedAt { get; set; }
    }
}
