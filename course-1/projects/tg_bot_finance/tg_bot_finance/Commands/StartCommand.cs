using System;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using tg_bot_finance.DTO;

namespace tg_bot_finance.Commands
{
    public class StartCommand : IBotCommand
    {
        public string Trigger => "/start";
        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(
                                    new List<InlineKeyboardButton[]>()
                                    {
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("Конвертировать валюту", "button1"),
                                        }
                                    });
            await bot.SendMessage(
                chatId,
                "💸 Добро пожаловать в бот <b>конвертер валют</b>! 🚀 \n \n 💫 Ваш надежный помощник для мгновенного конвертирования валют по самым актуальным курсам. 🔄 ",
                parseMode: ParseMode.Html,
                replyMarkup: inlineKeyboard);
        }
    }
}

