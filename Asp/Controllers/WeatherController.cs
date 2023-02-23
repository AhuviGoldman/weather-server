using Asp.services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _serviceWeather;

        public WeatherController(IWeatherService serviceWeather)
        {
            _serviceWeather = serviceWeather;
        }

        [HttpGet("{cityName}")]
        public async Task<string> GetTempAndConditionByCity(string cityName)
        {
            return await _serviceWeather.GetByCityNameAsync(cityName);
        }

        [HttpGet("3days/{cityName}")]
        public async Task<string> GetTempAndConditionByCityFor3DaysAsync(string cityName)
        {
            return await _serviceWeather.Get3DaysByCityNameAsync(cityName);
        }

        [HttpGet("random/{number1}/{number2}")]
        public int GetRandomNumber(int number1, int number2)
        {
            DateTime dt = DateTime.Now;
            int ms = dt.Millisecond;
            int max = Math.Max(number1, number2);
            int min = Math.Min(number1, number2);
            return (ms % (max - min + 1)) + min;
        }
    }
}

