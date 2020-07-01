using RestSharp;

namespace WeatherSample.DataProvider
{
    public static class WeatherApiBase
    {
        public static readonly RestClient Client = new RestClient("https://api.weatherbit.io/v2.0");
    }
}