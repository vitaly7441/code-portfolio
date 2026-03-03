using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace tg_bot_code
{
    public class WeekCommand : ICommand
    {
        protected readonly IScheduleRepository _scheduleRepository;

        public WeekCommand(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }


        public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
        {
            var chatId = update.Message!.Chat.Id;
            var text = update.Message!.Text ?? string.Empty;

            var parts = text.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                await botClient.SendMessage(
                    chatId,
                    "Использование: /week [группа]\nНапример: /week 9А(рус.)",
                    cancellationToken: ct);
                return;
            }

            var groupName = parts[1].Trim();

            var schedule = _scheduleRepository.Load();
            var group = schedule.Groups
                .FirstOrDefault(g => string.Equals(g.Group, groupName, StringComparison.OrdinalIgnoreCase));

            if (group == null)
            {
                await botClient.SendMessage(
                    chatId,
                    $"Для группы {groupName} нет расписания.",
                    cancellationToken: ct);
                return;
            }

            var lines = new List<string> { $"Полное расписание для {groupName}:" };

            foreach (var day in group.Days)
            {
                lines.Add($"\n{day.Day}:");
                if (day.Lessons == null || day.Lessons.Count == 0)
                {
                    lines.Add("  нет уроков");
                }
                else
                {
                    lines.AddRange(
                        day.Lessons.Select(
                            (l, i) => $"  {i + 1}. {l.Time} -- {l.Subject} {(string.IsNullOrEmpty(l.Teacher) ? "" : "(" + l.Teacher + ")")}"
                        )
                    );
                }
            }

            await botClient.SendMessage(chatId, string.Join('\n', lines), cancellationToken: ct);
        }
    }
}