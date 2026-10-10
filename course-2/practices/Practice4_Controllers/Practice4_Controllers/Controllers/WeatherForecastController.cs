using Microsoft.AspNetCore.Mvc;

namespace Practice4_Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("{days}")]
    public IEnumerable<WeatherForecast> GetWithDays([FromRoute] int days)
    {
        return Enumerable.Range(1, days).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }

    [HttpGet("filter")]
    public IEnumerable<WeatherForecast> GetFiltered(
    [FromQuery] int minTemp,
    [FromQuery] int maxTemp)
    {
        var data = Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        return data.Where(w => w.TemperatureC >= minTemp && w.TemperatureC <= maxTemp);
    }

    [HttpGet("check-header")]
    public string CheckHeader([FromHeader(Name = "X-Client")] string client)
    {
        Response.Headers["X-Echo-Client"] = client ?? "unknown";
        return $"Запрос пришёл от клиента: {client}";
    }
}

