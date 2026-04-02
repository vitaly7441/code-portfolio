using ExpenseTrackerBot.Services;

var builder = WebApplication.CreateBuilder(args);

// Получаем токен бота из конфигурации (например, appsettings.json)
var botToken = builder.Configuration["TelegramBot:Token"];
if (string.IsNullOrEmpty(botToken))
{
    throw new ArgumentNullException("Telegram Bot Token is not configured. Please set TelegramBot:Token in appsettings.json.");
}

// Регистрируем сервисы
builder.Services.AddSingleton<ExpenseStorageService>();
builder.Services.AddSingleton<TelegramBotService>(provider =>
    new TelegramBotService(botToken, provider.GetRequiredService<ExpenseStorageService>()));

// Регистрируем HttpClient для использования в TelegramBotService (если нужно)
// builder.Services.AddHttpClient("TelegramBotClient").AddHttpMessageHandler(() => new!';
// builder.Services.AddTransient((provider) => new TelegramBotClient(botToken)); // Альтернатива, если не нужно DI HTTP клиента

// Конфигурация для вебхука (если используется)
// var webhookUrl = builder.Configuration["TelegramBot:WebhookUrl"];
// if (!string.IsNullOrEmpty(webhookUrl))
// {
//     builder.Services.AddHostedService<ConfigureWebhookHostedService>();
// }

// Используем контроллер для обработки обновлений
builder.Services.AddControllers();

var app = builder.Build();

// Конфигурация middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var botService = app.Services.GetRequiredService<TelegramBotService>();
var botInfo = await botService.GetMeAsync();
Console.WriteLine($"Bot started: @{botInfo.Username}");

// Пример установки вебхука (если требуется, настройте URL в appsettings.json)
var webhookUrl = builder.Configuration["TelegramBot:WebhookUrl"];
if (!string.IsNullOrEmpty(webhookUrl))
{
    await botService.SetWebhookAsync(webhookUrl);
    Console.WriteLine($"Webhook set to: {webhookUrl}");
}


app.Run();
