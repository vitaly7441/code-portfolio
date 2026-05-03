using System.Text.Json;
using Telegram.Bot;
using tg_bot_finance.Commands;
using tg_bot_finance.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
}); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBotCommand, StartCommand>();
builder.Services.AddSingleton<IBotCommand, ButtonHandlerCommand>();
builder.Services.AddSingleton<TelegramUpdateProcessor>();
builder.Services.Configure<TelegramSettings>(
    builder.Configuration.GetSection("Telegram"));
builder.Services.AddSingleton<ITelegramBotClient>(sp =>
{
    var token = builder.Configuration["Telegram:BotToken"];
    return new TelegramBotClient(token!);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();