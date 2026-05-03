using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;
using tg_bot_code_model.Interfaces;

namespace tg_bot_code_model.Commands
{
    public class UndoCommand : IBotCommand
    {
        private readonly ILogger<UndoCommand> _logger;
        private readonly IChatModelRepository _chatModelRepository;

        public UndoCommand(
            ILogger<UndoCommand> logger,
            IChatModelRepository chatModelRepository)
        {
            _logger = logger;
            _chatModelRepository = chatModelRepository;
        }

        public string Trigger => "/undo";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            _logger.LogInformation("Команда /undo выполнена для чата {ChatId}", chatId);

            var removedAssistant = await _chatModelRepository.RemoveLastMessageAsync(chatId);

            if (removedAssistant)
            {
                await _chatModelRepository.RemoveLastMessageAsync(chatId);
                await bot.SendMessage(chatId, "Последний обмен сообщениями удалён.");
            }
            else
            {
                await bot.SendMessage(chatId, "История пуста. Нечего удалять.");
            }
        }
    }
}

