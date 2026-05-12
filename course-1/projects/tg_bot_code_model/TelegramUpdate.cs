using System;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace tg_bot_code_model.Dtos
{
    public class TelegramUpdate
    {
        [Required]
        public int UpdateId { get; set; }
        public TelegramMessage? Message { get; set; }
        public TelegramMessage? EditedMessage { get; set; }
    }
}

