using Microsoft.AspNetCore.Mvc;
using Gates.Services;
using Gates.Models;

namespace Gates.Controllers;

[ApiController]
[Route("/api/gates")]
public class GatesController : ControllerBase
{
    private readonly IAccessValidator _validator;

    public GatesController(IAccessValidator validator) {
        _validator = validator;
    }

    /// <summary>
    /// Проверка кода доступа
    /// </summary>
    /// <param name="request">JSON с кодом доступа</param>
    /// <returns>JSON результат проверки с перечнем ошибок, если есть(isValid, список ошибок, сообщение)</returns>
    /// <response code = "200">JSON результат проверки с перечнем ошибок(если есть)</response>
    /// <response code = "400">Отсутствует тело запроса или пустой код</response>
    [HttpPost("validate")]
    [ProducesResponseType(typeof(ValidResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult ValidateCode([FromBody] AccessCodeRequest request) {

        if (request == null || string.IsNullOrWhiteSpace(request.AccessCode)) {
            return BadRequest(new ErrorResponse{ Message = "Поле accessCode обязательно и не может быть пустым." });
        }

        var result = _validator.Validate(request.AccessCode);

        return Ok(result);
    }
}

