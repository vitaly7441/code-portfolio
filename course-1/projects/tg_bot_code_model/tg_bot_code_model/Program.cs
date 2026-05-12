using Telegram.Bot;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using tg_bot_code_model.Commands;
using tg_bot_code_model.Implementations;
using tg_bot_code_model.Interfaces;
using tg_bot_code_model.Settings;
using Serilog;

Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()
             .WriteTo.File("logs/app-.log", rollingInterval: RollingInterval.Day)
             .CreateBootstrapLogger();


var builder = WebApplication.CreateBuilder(args);
var telegramToken = "8708367455:AAEJV9rwHCzq3i7IZT2T3XabvaolUkNfSVQ";

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<IBotCommand, StartCommand>();
builder.Services.AddSingleton<IBotCommand, HelpCommand>();
builder.Services.AddSingleton<TelegramUpdateProcessor>();
builder.Services.AddSingleton<IBotCommand, StatsCommand>();
builder.Services.AddSingleton<IBotCommand, ClearCommand>();
builder.Services.AddSingleton<IBotCommand, UndoCommand>();
builder.Services.AddSingleton<IBotCommand, SummarizeCommand>();
builder.Services.AddSingleton<IBotCommand, JokeCommand>();
builder.Services.AddHttpClient<IChatApiClient, HttpChatApiClient>();
builder.Services.AddSingleton<IChatModelRepository, ChatModelRepository>();
builder.Services.Configure<ChatApiSettings>(
    builder.Configuration.GetSection("ChatApi"));
builder.Services.Configure<TelegramSettings>(
    builder.Configuration.GetSection("Telegram"));
builder.Services.AddSingleton<ITelegramBotClient>(sp =>
{
    var token = builder.Configuration["Telegram:BotToken"];
    return new TelegramBotClient(token!);
});
builder.Services.AddLogging();



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