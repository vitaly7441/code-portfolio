using System;
using static tg_bot_code.CommandDispatcher;
using System.Text.Json;
using tg_bot_code;

namespace tg_bot_code
{
    public class JsonScheduleRepository : IScheduleRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new() { PropertyNameCaseInsensitive = true };

        public JsonScheduleRepository(string path)
        {
            _path = path;
            if (!File.Exists(_path))
            {
                var sample = new ScheduleFile
                {
                    Groups = new List<GroupSchedule>
               {
                   new GroupSchedule
                   {
                       Group = "9А",
                       Days = new List<DaySchedule>
                       {
                           new DaySchedule { Day = "Понедельник", Lessons = new List<Lesson> {
                               new Lesson("08:30","Литература","Иванов И.В."),
                               new Lesson("08:30","Биология","Сергеев В.П"),
                               new Lesson("08:30","Геометрия","Лиский В.В"),
                               new Lesson("08:30","Физика","Дроздова А.Р"),
                               new Lesson("08:30","Русский язык","Попов Е.С")
                           } },

                           new DaySchedule { Day = "Вторник", Lessons = new List<Lesson> {
                               new Lesson("08:30","История","Михайлов В.П."),
                               new Lesson("08:30","География","Петрова Е.Б."),
                               new Lesson("08:30","Химия","Васильев И.В."),
                               new Lesson("08:30","Геометрия","Лиский В.В"),
                               new Lesson("08:30","Физика","Дроздова А.Р")
                           } },
                           new DaySchedule { Day = "Среда", Lessons = new List<Lesson>() {
                               new Lesson("08:30","Русский язык","Попов Е.С"),
                               new Lesson("08:30","География","Петрова Е.Б."),
                               new Lesson("08:30","Химия","Васильев И.В."),
                               new Lesson("08:30","Английский язык","Смирнова К.Г."),
                               new Lesson("08:30","Геометрия","Лиский В.В"),
                               new Lesson("08:30","Биология","Сергеев В.П")

                           }},
                           new DaySchedule { Day = "Четверг", Lessons = new List<Lesson>() {
                               new Lesson("08:30","Физика","Дроздова А.Р"),
                               new Lesson("08:30","Химия","Васильев И.В."),
                               new Lesson("08:30","Геометрия","Лиский В.В"),
                               new Lesson("08:30","География","Петрова Е.Б."),
                               new Lesson("08:30","Английский язык","Смирнова К.Г.")
                           } },
                           new DaySchedule { Day = "Пятница", Lessons = new List<Lesson>() {
                               new Lesson("08:30","Биология","Сергеев В.П"),
                               new Lesson("08:30","Геометрия","Лиский В.В"),
                               new Lesson("08:30","Физика","Дроздова А.Р"),
                               new Lesson("08:30","Русский язык","Попов Е.С"),
                               new Lesson("08:30","География","Петрова Е.Б."),
                               new Lesson("08:30","Английский язык","Смирнова К.Г.")
                           } },
                           new DaySchedule { Day = "Суббота", Lessons = new List<Lesson>() },
                           new DaySchedule { Day = "Воскресенье", Lessons = new List<Lesson>() }
                       }
                   }
               }
                };
                File.WriteAllText(_path, JsonSerializer.Serialize(sample, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        public ScheduleFile Load()
        {
            using var s = File.OpenRead(_path);
            return JsonSerializer.Deserialize<ScheduleFile>(s, _opts) ?? new ScheduleFile();
        }
    }
}

