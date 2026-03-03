using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace tg_bot_code
{
    public class HelpCommand : ICommand
    {
        public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
        {
            var chatId = update.Message!.Chat.Id;
            string text = "Доступные команды:\n" +
                          "/start - приветствие\n" +
                          "/help - помощь\n" +
                          "/week - расписание\n";

            await botClient.SendMessage(chatId, text, cancellationToken: ct);
        }
    }
}

