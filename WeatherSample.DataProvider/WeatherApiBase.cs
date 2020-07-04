using RestSharp;

namespace WeatherSample.DataProvider
{
    public static class WeatherApiBase
    {
        /// <summary>
        /// Read only RestClient class instance, with passed end-point
        /// of server for fetching weather data from it.
        /// </summary>
        public static readonly RestClient Client = new RestClient(
            "https://community-open-weather-map.p.rapidapi.com/forecast"
        );
    }
}