using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;

namespace tg_bot_code_model.Commands
{
    public class StartCommand : IBotCommand
    {
        private readonly ILogger<StartCommand> _logger;

        public StartCommand(ILogger<StartCommand> logger)
        {
            _logger = logger;
        }

        public string Trigger => "/start";
        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            _logger.LogInformation("Команда /start выполнена для чата {ChatId}", chatId);
            await bot.SendMessage(chatId, "Привет! Я OpenAI-бот. Отправь сообщение -- я передам его сторонней модели и верну ответ.\n/help для списка команд.");
        }
    }
}

