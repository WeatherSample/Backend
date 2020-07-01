using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherSample.Models;

namespace WeatherSample.Controllers
{
    [ApiController]
    [Route("/api/cities")]
    public class WeatherCitiesController : ControllerBase
    {
        [HttpGet("/all")]
        public async Task<WeatherCities> All()
        {
            // todo: return all weather cities.
        }

        [HttpPost("/update")]
        public async Task<WeatherCities> Update()
        {
            // todo: force update and re-parse cities from site.
        }
    }
}