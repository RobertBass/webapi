using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }


    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    [Route("weatherforecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Getting Weather Forecast");
        return ListWeatherForecast;
    }

    
    [HttpPost]
    [Route("Post/weatherforecasts")]
    [Route("weatherforecast")]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok(weatherForecast);
    }


    [HttpDelete("{index}")]
    [Route("Delete/weatherforecast/{index}")]
    [Route("weatherforecast/{index}")]
    //[Route("Delete/weatherforecast")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }
}