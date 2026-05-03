using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using tg_bot_finance.DTO;
using tg_bot_finance.Commands;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;


namespace tg_bot_finance.Calculations
{
    public class CalculateClass
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task Convert(TelegramUpdate update, ITelegramBotClient bot, long chatId, string fromValue, string toValue, string _convertionNumber)
        {
            string FromCurrency = "", ToCurrency = "";
            int convertionNumber = int.Parse(_convertionNumber);

            switch (fromValue)
            {
                case "🇷🇺 Рубль":
                    FromCurrency = "RUB";
                    break;
                case "🇺🇸 Доллар":
                    FromCurrency = "USD";
                    break;
                case "🇪🇺 Евро":
                    FromCurrency = "EUR";
                    break;
                case "🇨🇳 Юань":
                    FromCurrency = "CNY";
                    break;
            }

            switch (toValue)
            {
                case "🇷🇺 Рубль":
                    ToCurrency = "RUB";
                    break;
                case "🇺🇸 Доллар":
                    ToCurrency = "USD";
                    break;
                case "🇪🇺 Евро":
                    ToCurrency = "EUR";
                    break;
                case "🇨🇳 Юань":
                    ToCurrency = "CNY";
                    break;
            }

            try
            {
                var response = await _httpClient.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js");
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var cbrData = JsonSerializer.Deserialize<CbrResponse>(jsonContent);

                if (cbrData?.Valute == null)
                {
                    await bot.SendMessage(chatId, "Не удалось получить данные о курсах валют.");
                    return;
                }

                decimal resultAmount;

                if (FromCurrency == "RUB" && ToCurrency != "RUB")
                {
                    if (!cbrData.Valute.TryGetValue(ToCurrency, out var toRate))
                    {
                        await bot.SendMessage(chatId, $"Не найден курс для валюты {ToCurrency}.");
                        return;
                    }
                    decimal toRatePerUnit = toRate.Value / toRate.Nominal;
                    resultAmount = convertionNumber / toRatePerUnit;
                }
                else if (FromCurrency != "RUB" && ToCurrency == "RUB")
                {
                    if (!cbrData.Valute.TryGetValue(FromCurrency, out var fromRate))
                    {
                        await bot.SendMessage(chatId, $"Не найден курс для валюты {FromCurrency}.");
                        return;
                    }
                    decimal fromRatePerUnit = fromRate.Value / fromRate.Nominal;
                    resultAmount = convertionNumber * fromRatePerUnit;
                }
                else if (FromCurrency == "RUB" && ToCurrency == "RUB")
                {
                    resultAmount = convertionNumber;
                }
                else
                {
                    if (!cbrData.Valute.TryGetValue(FromCurrency, out var fromRate) ||
                        !cbrData.Valute.TryGetValue(ToCurrency, out var toRate))
                    {
                        await bot.SendMessage(chatId, $"Не найдены курсы для валют {FromCurrency} или {ToCurrency}.");
                        return;
                    }

                    decimal fromRatePerUnit = fromRate.Value / fromRate.Nominal;
                    decimal toRatePerUnit = toRate.Value / toRate.Nominal;

                    decimal amountInRubles = convertionNumber * fromRatePerUnit;
                    resultAmount = amountInRubles / toRatePerUnit;
                }
                string formattedResultAmount = resultAmount.ToString("N2", CultureInfo.GetCultureInfo("ru-RU"));
                string formattedConvertionNumber = convertionNumber.ToString("N0", CultureInfo.GetCultureInfo("ru-RU"));
                string message = $"🎉 Конвертация завершена!\n\n" +
                                 $"{formattedConvertionNumber} {fromValue} = {formattedResultAmount} {toValue}";

                var againKeyboard = new InlineKeyboardMarkup(
                                    new List<InlineKeyboardButton[]>()
                                    {
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("✅ Конвертировать заново", "againConvertButton"),
                                        }
                                    });

                await bot.EditMessageText(
                    chatId: chatId,
                    messageId: update.CallbackQuery.Message.MessageId,
                    text: message,
                    replyMarkup: againKeyboard
                );
            }
            catch (HttpRequestException ex)
            {
                await bot.SendMessage(chatId, $"Ошибка подключения к ЦБ РФ: {ex.Message}");
            }
            catch (JsonException ex)
            {
                await bot.SendMessage(chatId, $"Ошибка обработки данных: {ex.Message}");
            }
            catch (Exception ex)
            {
                await bot.SendMessage(chatId, $"Неожиданная ошибка: {ex.Message}");
            }
        }
    }
}
