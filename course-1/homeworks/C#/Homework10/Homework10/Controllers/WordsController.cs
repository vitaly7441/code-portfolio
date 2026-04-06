using Microsoft.AspNetCore.Mvc;
namespace Homework10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private static List<string> words = new List<string>() {
        "Word1",
        "Word2",
        "Word3"
    };

    [HttpGet]
    public IActionResult GetAllWords()
    {
        foreach (var i in words) {
            Console.WriteLine(i);
        }
        return Ok(words);
    }

    [HttpPost]
    public IActionResult AddWord(string word)
    {
        words.Add(word);
        return Ok(words);
    }

    [HttpDelete]
    public IActionResult DeleteWord(int index)
    {
        words.Remove(words[index]);
        return Ok(words);
    }


}

