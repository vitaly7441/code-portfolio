using System;
namespace Keeper.Dtos
{
    public class PerformActionRequest
    {
        public string Action { get; set; } = string.Empty;
    }

    public class ActionResponse
    {
        public int VisitorId { get; set; }
        public int TrustLevel { get; set; }
        public string PerformedAction { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    public class AccessResponse
    {
        public int VisitorId { get; set; }
        public int TrustLevel { get; set; }
        public bool AccessGranted { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class VisitorResponse
    {
        public int Id { get; set; }
        public int TrustLevel { get; set; }
        public List<string> ActionsDone { get; set; } = new();
    }
}

