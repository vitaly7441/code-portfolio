using System;
using Telegram.Bot;
using tg_bot_code_model.Dtos;
using tg_bot_code_model.Interfaces;
using tg_bot_code_model.Repositories.Models;

namespace tg_bot_code_model.Commands
{
	public class JokeCommand : IBotCommand
    {
        private readonly ILogger<JokeCommand> _logger;
        private readonly IChatModelRepository _chatModelRepository;
        private readonly IChatApiClient _chatApiClient;

        public JokeCommand(
            ILogger<JokeCommand> logger,
            IChatModelRepository chatModelRepository,
            IChatApiClient chatApiClient)
        {
            _logger = logger;
            _chatModelRepository = chatModelRepository;
            _chatApiClient = chatApiClient;
        }

        public string Trigger => "/joke";

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            _logger.LogInformation("Команда /joke выполнена для чата {ChatId}", chatId);

            var history = await _chatModelRepository.GetHistoryAsync(chatId);
            var jokePrompt = "Расскажи какую-нибудь шутку.";
            var summarizeHistory = history.ToList();

            summarizeHistory.Add(new OpenApiResponse.Message
            {
                Role = "user",
                Content = jokePrompt
            });

            try
            {
                var summary = await _chatApiClient.SendMessageAsync(jokePrompt, summarizeHistory);

                var response = $"Шутка: {summary}";
                await bot.SendMessage(chatId, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при попытке генерации шутки для чата {ChatId}", chatId);
                await bot.SendMessage(chatId, "Ошибка при попытке сгенерировать шутку. Попробуйте позже.");
            }
        }
    }
}

