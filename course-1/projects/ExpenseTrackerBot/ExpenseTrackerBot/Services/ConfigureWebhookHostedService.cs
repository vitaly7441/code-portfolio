using System;
using Telegram.Bot;

namespace ExpenseTrackerBot.Services
{
	public class ConfigureWebhookHostedService: IHostedService
	{
        private readonly IServiceProvider _serviceProvider;
        private readonly string? _botToken;
        private readonly string? _webhookUrl;

        public ConfigureWebhookHostedService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _botToken = configuration["TelegramBot:Token"];
            _webhookUrl = configuration["TelegramBot:WebhookUrl"];
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_botToken) || string.IsNullOrEmpty(_webhookUrl))
            {
                Console.WriteLine("Telegram Bot Token or Webhook URL is not configured. Skipping webhook setup.");
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            var telegramBotClient = new TelegramBotClient(_botToken);
            try
            {
                await telegramBotClient.SetWebhook(_webhookUrl, cancellationToken: cancellationToken);
                Console.WriteLine($"Webhook set to: {_webhookUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting webhook: {ex.Message}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

