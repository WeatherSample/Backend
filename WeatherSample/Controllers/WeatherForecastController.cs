using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherSample.Dal.Abstract;
using WeatherSample.Services;

namespace WeatherSample.Controllers
{
    [ApiController]
    [Route("/api/forecast")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _repository;
        private readonly WeatherDataFetchService _service;

        public WeatherController(
            IWeatherRepository repository, WeatherDataFetchService service
        )
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet("/{city}")]
        public async Task<IActionResult> ForecastOf(string city)
        {
            var result = await _service.GetByIdAsync(city);
            return result != null
                ? (IActionResult) Ok(result)
                : NotFound($"City with name {city} not found, try another.");
        }

        [HttpPost("/refresh-all")]
        public async Task<IActionResult> RefreshAll()
        {
            await _repository.DeleteAll();
            return Ok();
        }
    }
}