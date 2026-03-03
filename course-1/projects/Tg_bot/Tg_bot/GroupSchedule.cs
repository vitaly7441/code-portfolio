using System;
using tg_bot_code;

namespace tg_bot_code
{
    public class GroupSchedule
    {
        public string Group { get; set; } = string.Empty;
        public List<DaySchedule> Days { get; set; } = new();
    }
}

