using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    [HttpGet("by-test/{testId}")]
    public IActionResult GetAnswersByTestId(int testId) => Ok($"Ответы для теста {testId}");

    [HttpPost]
    public IActionResult CreateAnswer() => Created("/api/answers/1", "Вопрос создан");

    [HttpPut("{id}")]
    public IActionResult UpdateAnswer(int id) => NoContent();

    [HttpDelete("{id}")]
    public IActionResult DeleteAnswer(int id) => NoContent();
}