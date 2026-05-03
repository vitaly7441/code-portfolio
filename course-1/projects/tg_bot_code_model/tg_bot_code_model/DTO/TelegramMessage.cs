using System;
using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace tg_bot_code_model.Dtos
{
    public class TelegramMessage
    {
        [Required]
        public int MessageId { get; set; }
        public Chat Chat { get; set; } = new Chat();
        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string? Text { get; set; }
        [Required]
        public int Date { get; set; }
    }

}

