using System;
namespace Keeper.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public int TrustLevel { get; set; } = 0;
        public List<ActionHistory> ActionHistories { get; set; } = new();
    }
}

