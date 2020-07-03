using System.Net;
using System.Threading.Tasks;
using RestSharp;
using WeatherSample.Models;

namespace WeatherSample.DataProvider
{
    public class WeatherExternalApiService
    {
        private readonly string _token;

        /// <param name="serviceToken">Token for interacting with weather provider api.</param>
        public WeatherExternalApiService(string serviceToken) => _token = serviceToken;

        /// <summary>
        /// Do fetch weather data of passed city from weather provider.
        /// </summary>
        /// <param name="city">City name to fetch.</param>
        /// <returns>Null of city not exist otherwise model based on server json in response.</returns>
        public async Task<City?> FetchCity(string city)
        {
            // Log.Trace($"Doing fetch forecast data of city {city}");
            var request = new RestRequest("forecast/hourly")
                .AddParameter("city", city)
                .AddParameter("key", _token)
                .AddParameter("hours", "120"); // that service anyway will return 48hrs :(
            var response = await WeatherApiBase.Client.ExecuteGetAsync<City>(request);
            return response.StatusCode == HttpStatusCode.NoContent ? null : response.Data;
        }
    }
}