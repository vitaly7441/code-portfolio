using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using tg_bot_code_model.Interfaces;
using tg_bot_code_model.Repositories.Models;
using tg_bot_code_model.Settings;

namespace tg_bot_code_model.Implementations
{
    public class HttpChatApiClient : IChatApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ChatApiSettings _chatSettings;
        private readonly ILogger<HttpChatApiClient> _logger;

        public HttpChatApiClient(HttpClient httpClient, IOptions<ChatApiSettings> chatOptions, ILogger<HttpChatApiClient> logger)
        {
            _chatSettings = chatOptions.Value;
            _httpClient = httpClient;
            _logger = logger;

            _httpClient.BaseAddress = new Uri(_chatSettings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _chatSettings.ApiKey);
        }

        public async Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history)
        {
            _logger.LogInformation("Отправка запроса к модели {Model}", _chatSettings.DefaultModel);

            var payload = new OpenApiRequest()
            {
                Model = _chatSettings.DefaultModel,
                Messages = history.ToList(),
                MaxTokens = 1000
            };

            var response = await _httpClient.PostAsJsonAsync("", payload);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadFromJsonAsync<OpenApiResponse?>();
            if (body?.Choices != null && body.Choices.Length > 0)
            {
                var content = body.Choices[0].Message.Content;
                _logger.LogInformation($"Получен ответ от API {content}");
                return content;
            }

            _logger.LogWarning("API вернул пустой ответ");
            return await response.Content.ReadAsStringAsync();
        }
    }
}