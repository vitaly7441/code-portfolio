using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using tg_bot_finance.Commands;
using tg_bot_finance.DTO;

namespace tg_bot_finance.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateController : ControllerBase
{
    private readonly TelegramUpdateProcessor _processor;

    public UpdateController(TelegramUpdateProcessor processor)
    {
        _processor = processor;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TelegramUpdate update)
    {
        //Console.WriteLine($"Update ID: {update.UpdateId}");
        //Console.WriteLine($"Message: {(update.Message != null ? "заполнен" : "null")}");
        //Console.WriteLine($"CallbackQuery: {(update.CallbackQuery != null ? "заполнен" : "null")}");

        //if (update.CallbackQuery != null)
        //{
        //    Console.WriteLine("--NoNULL:--");
        //    Console.WriteLine($"Callback ID: {update.CallbackQuery.Id}");
        //    Console.WriteLine($"Callback Data: {update.CallbackQuery.Data}");
        //    Console.WriteLine($"From User ID: {update.CallbackQuery.From?.Id}");
        //}

        if (!ModelState.IsValid)
            return BadRequest();

        _ = Task.Run(() => _processor.HandleAsync(update));

        return Ok();
    }
}