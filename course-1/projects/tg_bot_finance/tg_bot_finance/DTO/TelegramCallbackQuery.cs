using System;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace tg_bot_finance.DTO
{
	public class TelegramCallbackQuery
	{
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("from")]
        public TelegramUser? From { get; set; }

        [JsonPropertyName("message")]
        public TelegramMessage? Message { get; set; }

        [JsonPropertyName("inline_message_id")]
        public string? InlineMessageId { get; set; }

        [JsonPropertyName("chat_instance")]
        public string? ChatInstance { get; set; }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("game_short_name")]
        public string? GameShortName { get; set; }
    }
}

