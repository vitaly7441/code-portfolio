using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;
using tg_bot_code_model.Interfaces;

namespace tg_bot_code_model.Commands
{
    public class StatsCommand : IBotCommand
    {
        private readonly IChatModelRepository _chatModelRepository;

        public StatsCommand(IChatModelRepository chatModelRepository)
        {
            _chatModelRepository = chatModelRepository;
        }

        public string Trigger => "/stats";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            var stats = await _chatModelRepository.GetStatsAsync(chatId);

            var message = $"Статистика чат\n\n" +
                          $"Сообщений от вас: {stats.UserMessages}\n" +
                          $"Ответов бота: {stats.AssistantMessages}\n" +
                          $"Всего сообщений: {stats.TotalMessages}\n\n" +
                          $"Токенов (приблизительно):\n" +
                          $"  - От вас: ~{stats.EstimatedUserTokens}\n" +
                          $"  - От бота: ~{stats.EstimatedAssistantTokens}\n" +
                          $"  - Всего: ~{stats.EstimatedTotalTokens}";

            await bot.SendMessage(chatId, message);
        }
    }
}

