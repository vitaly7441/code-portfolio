using System;
using System.Text.Json.Serialization;

namespace tg_bot_finance.DTO
{
    public class TelegramUser
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("language_code")]
        public string? LanguageCode { get; set; }
    }
}

