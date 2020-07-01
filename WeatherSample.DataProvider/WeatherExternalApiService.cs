using System.Net;
using System.Threading.Tasks;
using RestSharp;
using WeatherSample.Models;

namespace WeatherSample.DataProvider
{
    public class WeatherExternalApiService
    {
        private readonly string _token;
        public WeatherExternalApiService(string serviceToken) => _token = serviceToken;

        public async Task<City?> FetchCity(string city)
        {
            var request = new RestRequest("forecast/hourly")
                .AddParameter("city", city)
                .AddParameter("key", _token)
                .AddParameter("hours", "120");
            var response = await WeatherApiBase.Client.ExecuteGetAsync<City>(request);
            return response.StatusCode == HttpStatusCode.NoContent ? null : response.Data;
        }
    }
}