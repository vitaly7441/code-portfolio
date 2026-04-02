using System;
namespace ExpenseTrackerBot.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
