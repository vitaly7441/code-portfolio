using System;
using static tg_bot_code.CommandDispatcher;

namespace tg_bot_code
{
    public class ScheduleFile
    {
        public List<GroupSchedule> Groups { get; set; } = new();
    }
}

