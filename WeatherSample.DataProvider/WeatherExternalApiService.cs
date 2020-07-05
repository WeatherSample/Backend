using System.Net;
using System.Threading.Tasks;
using RestSharp;
using static WeatherSample.Models.WeatherApiModel;

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
        public async Task<Temperatures?> FetchCity(string city)
        {
            var request = new RestRequest()
                .AddParameter("q", city)
                .AddParameter("units", "metric")
                .AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com")
                .AddHeader("x-rapidapi-key", _token);
            var response = await WeatherApiBase.Client.ExecuteGetAsync<Temperatures>(request);
            if (
                response.StatusCode == HttpStatusCode.NotFound ||
                response.StatusCode == HttpStatusCode.TooManyRequests
            ) return null;
            return response.Data;
        }
    }
}