using System;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using static tg_bot_code.CommandDispatcher;
using System.Text.Json;

namespace tg_bot_code {

    public interface ICommand
    {
        Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct);
    }

    public interface IScheduleRepository
    {
        ScheduleFile Load();
    }

    class Program
    {
        private const string ScheduleJson = "schedule.json";

        public static async Task Main()
        {
            Console.WriteLine("Запуск бота...");

            var token = "8716696565:AAGZYCiE7S-1KF6GI1RNr96opV-68D54ZJo";
            var botClient = new TelegramBotClient(token);

            var scheduleRepository = new JsonScheduleRepository(ScheduleJson);

            var dispatcher = new CommandDispatcher();
            dispatcher.Register("/start", new StartCommand());
            dispatcher.Register("/help", new HelpCommand());
            dispatcher.Register("/week", new WeekCommand(scheduleRepository));

            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() };

            botClient.StartReceiving(
                async (client, update, ct) => await dispatcher.DispatchAsync(update, client, ct),
                HandleErrorAsync,
                receiverOptions,
                cts.Token);

            var me = await botClient.GetMe();
            Console.WriteLine($"Бот запущен: @{me.Username}");
            Console.ReadLine();
            cts.Cancel();
        }

        static Task HandleErrorAsync(ITelegramBotClient bot, Exception ex, CancellationToken ct)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return Task.CompletedTask;
        }
    }
}