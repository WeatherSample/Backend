using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherSample.Models;

namespace WeatherSample.Controllers
{
    [ApiController]
    [Route("/api/forecast")]
    public class WeatherController : ControllerBase
    {
        [HttpGet("/of/{city}")]
        public async Task<Weathers> Of(string city)
        {
            // todo: return Weather object as json for selected city.
        }
    }
}