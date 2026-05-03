using System;
using tg_bot_code_model.Repositories.Models;

namespace tg_bot_code_model.Interfaces
{
    public interface IChatApiClient
    {
        Task<string> SendMessageAsync(string userMessage, IEnumerable<OpenApiResponse.Message> history);
    }
}

