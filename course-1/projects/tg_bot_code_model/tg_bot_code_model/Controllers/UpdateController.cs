using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using tg_bot_code_model.Commands;
using tg_bot_code_model.Dtos;

namespace tg_bot_code_model.Controllers
{
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
            await _processor.HandleAsync(update);
            return Ok();
        }
    }
}