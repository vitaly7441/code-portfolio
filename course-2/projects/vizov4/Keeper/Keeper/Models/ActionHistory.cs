using System;
namespace Keeper.Models
{
    public class ActionHistory
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; } = null!;
        public GuardianAction Action { get; set; }
        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    }
}

