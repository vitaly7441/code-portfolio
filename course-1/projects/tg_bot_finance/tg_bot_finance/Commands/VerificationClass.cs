using System;
using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using tg_bot_finance.DTO;

namespace tg_bot_finance.Commands
{
	public static class VerificationClass
	{
        public static string convertionNumber;
        public static async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId, string _convertionNumber)
        {
            convertionNumber = _convertionNumber;
            long number = long.Parse(_convertionNumber);
            string resultConvertionNumber = number.ToString("N0", CultureInfo.GetCultureInfo("ru-RU"));
            var inlineKeyboard = new InlineKeyboardMarkup(
                                    new List<InlineKeyboardButton[]>()
                                    {
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("✅ Подтвердить", "successButton"),
                                        },
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("⚙️ Изменить", "changeButton"),
                                        }
                                    });
            await bot.SendMessage(
                chatId,
                text:
                $"<b>Данные для конвертации:</b>" +
                $"\n\nИз: {ButtonHandlerCommand.fromCurrency}" +
                $"\nВ: {ButtonHandlerCommand.toCurrency}" +
                $"\nСумма: {resultConvertionNumber}" +
                "\n\nПроверьте данные и нажмите <b>Подтвердить</b> или измените их.",
                parseMode: ParseMode.Html,
                replyMarkup: inlineKeyboard);
        }
    }
}

