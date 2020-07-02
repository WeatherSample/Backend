using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherSample.Services;

namespace WeatherSample.Controllers
{
    [ApiController]
    [Route("/api/forecast")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherDataFetchService _service;
        public WeatherController(WeatherDataFetchService service) => _service = service;

        [HttpGet("/{city}")]
        public async Task<IActionResult> ForecastOf(string city)
        {
            var result = await _service.GetByIdAsync(city);
            return result != null
                ? (IActionResult) Ok(result)
                : NotFound($"City with name {city} not found, try another.");
        }
    }
}