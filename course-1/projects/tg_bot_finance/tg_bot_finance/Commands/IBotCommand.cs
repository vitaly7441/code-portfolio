using System;
using Telegram.Bot;
using tg_bot_finance.DTO;

namespace tg_bot_finance.Commands
{
	public interface IBotCommand
	{
		string Trigger { get; }
        Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId);
    }
}

