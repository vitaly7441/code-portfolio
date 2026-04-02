using System;
using System.Text;
using ExpenseTrackerBot.Models;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExpenseTrackerBot.Services
{
    public class TelegramBotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ExpenseStorageService _expenseStorageService;
        private readonly string _botToken;

        public TelegramBotService(string botToken, ExpenseStorageService expenseStorageService)
        {
            _botToken = botToken;
            _botClient = new TelegramBotClient(_botToken);
            _expenseStorageService = expenseStorageService;
        }

        public async Task HandleUpdateAsync(Update update)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                await HandleTextMessageAsync(update.Message);
            }
        }

        private async Task HandleTextMessageAsync(Message message)
        {
            if (message.Text == null)
            {
                await _botClient.SendMessage(message.Chat.Id, "Я понимаю только текст и команды.");
                return;
            }

            var userId = message.Chat.Id;
            var text = message.Text.Trim();

            if (text.StartsWith("/"))
            {
                await HandleCommandAsync(userId, text);
                return;
            }

            if (TryParseExpense(text, userId, out var expense))
            {
                _expenseStorageService.AddExpense(expense);
                await _botClient.SendMessage(message.Chat.Id, $"Записано: {expense.Amount} руб. ({expense.Reason})");
            }
            else
            {
                await _botClient.SendMessage(message.Chat.Id, "Ошибка: Начните сообщение с суммы (числа). Пример: 500 Обед");
            }
        }

        private bool TryParseExpense(string inputText, long userId, out Expense? expense)
        {
            expense = null;
            var parts = inputText.Split(' ', 2);
            if (parts.Length < 2)
                return false;

            if (decimal.TryParse(parts[0], out var amount))
            {
                expense = new Expense
                {
                    UserId = userId,
                    Amount = amount,
                    Reason = parts[1]
                };
                return true;
            }
            return false;
        }

        private async Task HandleCommandAsync(long userId, string command)
        {
            var now = DateTime.UtcNow;
            switch (command.ToLower())
            {
                case "/start":
                case "/help":
                    await SendHelpMessage(userId);
                    break;

                case "/today":
                    await SendTodayExpenses(userId, now);
                    break;

                case "/week":
                    await SendWeeklyExpenses(userId, now);
                    break;

                case "/month":
                    await SendMonthlyExpenses(userId, now);
                    break;

                case "/last":
                    await SendLastExpenses(userId, 10);
                    break;

                default:
                    await _botClient.SendMessage(userId, "Неизвестная команда. Введите /help для списка команд.");
                    break;
            }
        }

        private async Task SendHelpMessage(long userId)
        {
            var helpText = "Привет! Я помогу тебе вести учет расходов.\n\n" +
                           "Как добавить расход:\n" +
                           "Просто напиши сумму и причину через пробел. Например:\n" +
                           "<code>500 Обед</code>\n" +
                           "<code>1200.50 Такси до офиса</code>\n\n" +
                           "Доступные команды:\n" +
                           "/today - Расходы за сегодня\n" +
                           "/week - Расходы за последние 7 дней\n" +
                           "/month - Расходы за текущий месяц\n" +
                           "/last - Последние 10 трат\n" +
                           "/help или /start - Показать эту помощь";

            await _botClient.SendMessage(userId, helpText, ParseMode.Html);
        }

        private async Task SendTodayExpenses(long userId, DateTime now)
        {
            var startOfDay = now.Date;
            var endOfDay = startOfDay.AddDays(1);
            var expenses = _expenseStorageService.GetExpensesForPeriod(userId, startOfDay, endOfDay);
            var totalAmount = expenses.Sum(e => e.Amount);
            var count = expenses.Count;
            await _botClient.SendMessage(userId, $"За сегодня потрачено: {totalAmount:F2} руб. (записей: {count})");
        }

        private async Task SendWeeklyExpenses(long userId, DateTime now)
        {
            var startDate = now.AddDays(-6).Date;
            var endDate = now.Date.AddDays(1);
            var expenses = _expenseStorageService.GetExpensesForPeriod(userId, startDate, endDate);
            var totalAmount = expenses.Sum(e => e.Amount);
            await _botClient.SendMessage(userId, $"За последние 7 дней: {totalAmount:F2} руб.");
        }

        private async Task SendMonthlyExpenses(long userId, DateTime now)
        {
            var startOfMonth = new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var endOfMonth = startOfMonth.AddMonths(1);

            var expenses = _expenseStorageService.GetExpensesForPeriod(userId, startOfMonth, endOfMonth);
            var totalAmount = expenses.Sum(e => e.Amount);

            await _botClient.SendMessage(userId, $"За этот месяц: {totalAmount:F2} руб.");
        }

        private async Task SendLastExpenses(long userId, int count)
        {
            var expenses = _expenseStorageService.GetLastExpenses(userId, count);

            if (!expenses.Any())
            {
                await _botClient.SendMessage(userId, "У вас пока нет записей расходов.");
                return;
            }

            var responseBuilder = new StringBuilder("Последние траты:\n");
            var i = 1;
            foreach (var expense in expenses.OrderByDescending(e => e.CreatedAt)) // Убедимся, что сортировка по убыванию даты
            {
                var formattedDate = expense.CreatedAt.ToLocalTime().ToString("dd.MM HH:mm");
                responseBuilder.AppendLine($"{i}. {expense.Amount:F2} руб. | {expense.Reason} ({formattedDate})");
                i++;
            }

            await _botClient.SendMessage(userId, responseBuilder.ToString());
        }

        public async Task<IActionResult> SetWebhookAsync(string webhookUrl)
        {
            await _botClient.SetWebhook(webhookUrl);
            return new OkResult();
        }

        public async Task<User> GetMeAsync()
        {
            return await _botClient.GetMe();
        }

        public async Task SendMessageAsync(long chatId, string text)
        {
            using var httpClient = new HttpClient();
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
            var response = await httpClient.PostAsJsonAsync(url, new { chat_id = chatId, text = text });
            response.EnsureSuccessStatusCode();
        }

    }
}

