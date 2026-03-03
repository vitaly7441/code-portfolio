using System;
using static tg_bot_code.CommandDispatcher;

namespace tg_bot_code
{
    public class DaySchedule
    {
        public string Day { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new();
    }
}