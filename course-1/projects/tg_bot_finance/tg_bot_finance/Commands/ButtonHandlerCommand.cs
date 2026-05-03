using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using tg_bot_finance.DTO;
using tg_bot_finance.Calculations;
using static System.Net.Mime.MediaTypeNames;

namespace tg_bot_finance.Commands
{
    public class ButtonHandlerCommand : IBotCommand
    {
        public string Trigger => "button1";
        public static bool isConvertNumber = false;
        public static string fromCurrency, toCurrency;

        public async Task ExecuteAsync(TelegramUpdate update, ITelegramBotClient bot, long chatId)
        {
            switch (update.CallbackQuery?.Data)
            {
                case "button1":
                    {
                        await bot.AnswerCallbackQuery(update.CallbackQuery.Id);

                        var fromCurrencyKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("🇷🇺 Рубль", "fromRub"),
                                InlineKeyboardButton.WithCallbackData("🇺🇸 Доллар", "fromUsd")
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("🇪🇺 Евро", "fromEur"),
                                InlineKeyboardButton.WithCallbackData("🇨🇳 Юань", "fromCny")
                            }
                        });

                        await bot.EditMessageText(
                            chatId: chatId,
                            messageId: update.CallbackQuery.Message.MessageId,
                            text:
                            "💱 Выберите <b>из какой валюты</b> перевести:",
                            parseMode: ParseMode.Html,
                            replyMarkup: fromCurrencyKeyboard
                        );
                        break;
                    }
                case "fromRub":
                case "fromUsd":
                case "fromEur":
                case "fromCny":
                    {
                        await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
                        fromCurrency = update.CallbackQuery.Data switch
                        {
                            "fromRub" => "🇷🇺 Рубль",
                            "fromUsd" => "🇺🇸 Доллар",
                            "fromEur" => "🇪🇺 Евро",
                            "fromCny" => "🇨🇳 Юань",
                            _ => "неизвестная валюта"
                        };

                        var toCurrencyKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("🇷🇺 Рубль", "toRub"),
                                InlineKeyboardButton.WithCallbackData("🇺🇸 Доллар", "toUsd")
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("🇪🇺 Евро", "toEur"),
                                InlineKeyboardButton.WithCallbackData("🇨🇳 Юань", "toCny")
                            }
                        });
                        await bot.EditMessageText(
                            chatId: chatId,
                            messageId: update.CallbackQuery.Message.MessageId,
                            text:
                            $"✅ Выбрана исходная валюта: <b>{fromCurrency}</b>\n\n🔎 Теперь выберите валюту в которую хотите перевести:",
                            parseMode: ParseMode.Html,
                            replyMarkup: toCurrencyKeyboard
                        );
                        break;
                    }
                case "toRub":
                case "toUsd":
                case "toEur":
                case "toCny":
                    {
                        await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
                        toCurrency = update.CallbackQuery.Data switch
                        {
                            "toRub" => "🇷🇺 Рубль",
                            "toUsd" => "🇺🇸 Доллар",
                            "toEur" => "🇪🇺 Евро",
                            "toCny" => "🇨🇳 Юань",
                            _ => "неизвестная валюта"
                        };
                        await bot.EditMessageText(
                            chatId: chatId,
                            messageId: update.CallbackQuery.Message.MessageId,
                            text:
                            $"✅ Исходная валюта: <b>{fromCurrency}</b>"+
                            $"\n✅ Конечная валюта: <b>{toCurrency}</b>"+
                            "\n\n🔎 Теперь введите сумму конвертации:",
                            parseMode: ParseMode.Html
                        );
                        isConvertNumber = true;
                        break;
                    }
                case "successButton":
                    await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
                    await CalculateClass.Convert(update, bot, chatId, fromCurrency, toCurrency, VerificationClass.convertionNumber);
                    break;
                case "changeButton":
                    await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
                    var changeKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("Исходн.", "changeFrom"),
                                InlineKeyboardButton.WithCallbackData("Конечн.", "changeTo"),
                                InlineKeyboardButton.WithCallbackData("Сумму", "changeConvertionNumber")
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("⬅️ Назад", "changeBack")
                            }
                        });
                    await bot.EditMessageText(
                            chatId: chatId,
                            messageId: update.CallbackQuery.Message.MessageId,
                            text:
                            "⚙️ Что Вы хотите изменить?",
                            parseMode: ParseMode.Html,
                            replyMarkup: changeKeyboard
                        );
                    break;
                case "changeFrom":
                    //todo
                    break;
                case "changeTo":
                    //todo
                    break;
                case "changeConvertionNumber":
                    //todo
                    break;
                case "changeBack":
                    await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
                    await VerificationClass.ExecuteAsync(update, bot, chatId, VerificationClass.convertionNumber);
                    break;
                case "againConvertButton":
                    await bot.AnswerCallbackQuery(update.CallbackQuery.Id);
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
                    break;
                default:
                    await bot.SendMessage(
                        chatId: chatId,
                        text: "🤷‍♂ Что-то пошло не так. Нажмите /start"
                    );
                    break;
            }
        }
    }
}