//using System;
//using System.Net.Http;
//using Microsoft.AspNetCore.Mvc;
//using tg_bot_code_model.Commands;
//using tg_bot_code_model.Dtos;
//using tg_bot_code_model.Interfaces;


//namespace tg_bot_code_model.Controllers
//{
//    [ApiController]
//    [Route("api/chat")]
//    public class ChatTestController : ControllerBase
//    {
//        private readonly IChatApiClient chatApiClient;

//        public ChatTestController(IChatApiClient chatApiClient)
//        {
//            this.chatApiClient = chatApiClient;
//        }

//        [HttpPost("test")]
//    public async Task<IActionResult> Test([FromBody] ChatTestRequest request)
//    {
//        var answer = await chatApiClient.SendMessageAsync(request.Message);
//        return Ok(new { answer });
//    }
//}

//public record ChatTestRequest(string Message);

//}