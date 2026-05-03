using System;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace tg_bot_finance.DTO
{
	public class TelegramUpdate
	{
        [JsonPropertyName("update_id")]
        public int UpdateId { get; set; }

        [JsonPropertyName("callback_query")]
        public TelegramCallbackQuery? CallbackQuery { get; set; }

        [JsonPropertyName("message")]
        public TelegramMessage? Message { get; set; }

        [JsonPropertyName("edited_message")]
        public TelegramMessage? EditedMessage { get; set; }
    }
}

