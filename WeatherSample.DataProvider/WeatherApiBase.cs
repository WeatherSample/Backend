using RestSharp;

namespace WeatherSample.DataProvider
{
    public static class WeatherApiBase
    {
        /// <summary>
        /// Read only RestClient class instance, with passed end-point
        /// of server for fetching weather data from it.
        /// </summary>
        public static readonly RestClient Client = new RestClient("https://api.weatherbit.io/v2.0");
    }
}