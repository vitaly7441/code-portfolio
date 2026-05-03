using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;
using tg_bot_code_model.Interfaces;

namespace tg_bot_code_model.Commands
{
    public class ClearCommand : IBotCommand
    {

        private readonly ILogger<StartCommand> _logger;
        private readonly IChatModelRepository _chatModelRepository;

        //public ClearCommand(IChatModelRepository chatModelRepository)
        //{
        //    _chatModelRepository = chatModelRepository;
        //}

        public ClearCommand(IChatModelRepository chatModelRepository)
        {
            _chatModelRepository = chatModelRepository;
        }

        public string Trigger => "/clear";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            await _chatModelRepository.ClearHistoryAsync(chatId);

            var message = "История очищена\n\n" +
                          "Начните новый диалог -- я буду отвечать с чистого листа.";

            await bot.SendMessage(chatId, message);
        }
    }
}

