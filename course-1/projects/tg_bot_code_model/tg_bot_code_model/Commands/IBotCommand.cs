using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;

namespace tg_bot_code_model.Commands
{
    public interface IBotCommand
    {
        string Trigger { get; }
        Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId);
    }
}

