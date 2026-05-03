using System;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace tg_bot_finance.DTO
{
	public class TelegramMessage
	{
        [JsonPropertyName("message_id")]
        public int MessageId { get; set; }

        [JsonPropertyName("from")]
        public TelegramUser? From { get; set; }

        [JsonPropertyName("chat")]
        public Chat Chat { get; set; } = new Chat();

        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}

