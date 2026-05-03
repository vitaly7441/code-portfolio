using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using tg_bot_finance.DTO;

namespace tg_bot_finance.Commands
{
    public class TelegramUpdateProcessor
    {
        private readonly IEnumerable<IBotCommand> _commands;
        private readonly ITelegramBotClient _botClient;

        public TelegramUpdateProcessor(
            IEnumerable<IBotCommand> commands,
            ITelegramBotClient botClient)
        {
            _commands = commands;
            _botClient = botClient;
        }

        public async Task HandleAsync(TelegramUpdate update)
        {
            if (update.Message != null)
            {
                var chatId = update.Message.Chat.Id;
                var text = update.Message.Text.Trim();

                if (text.StartsWith("/"))
                {
                    var cmd = text.Split(' ', 2)[0];
                    var command = _commands.FirstOrDefault(c => c.Trigger.Equals(cmd, StringComparison.OrdinalIgnoreCase));
                    if (command != null)
                    {
                        await command.ExecuteAsync(update, _botClient, chatId);
                        return;
                    }
                    else
                    {
                        await _botClient.SendMessage(chatId, "Неизвестная команда. Используйте /start");
                        return;
                    }
                }
                else if (ButtonHandlerCommand.isConvertNumber) {
                    if (text.All(char.IsDigit))
                    {
                        await VerificationClass.ExecuteAsync(update, _botClient, chatId, text);
                        ButtonHandlerCommand.isConvertNumber = false;
                    }
                    else {
                        await _botClient.SendMessage(chatId, "❗Некорректное число, можно вводить только цифры!");
                    }
                } else
                {
                    await _botClient.SendMessage(chatId, "Неизвестная команда. Используйте /start");
                }
            }
            else if (update.CallbackQuery != null)
            {
                var buttonCommand = _commands.OfType<ButtonHandlerCommand>().FirstOrDefault();
                if (buttonCommand != null)
                {
                    await buttonCommand.ExecuteAsync(update, _botClient, update.CallbackQuery.Message?.Chat.Id ?? 0);
                }
            }
        }
    }
}