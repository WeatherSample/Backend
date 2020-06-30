using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSample.Models
{
    public class Weathers
    {
        [JsonProperty("data")] public List<WeatherBase> Data { get; set; }
        [JsonProperty("city_name")] public string CityName { get; set; }
    }

    public class WeatherBase
    {
        [JsonProperty("weather")] public Weather Weather { get; set; }
        [JsonProperty("uv")] public double Uv { get; set; }
        [JsonProperty("precip")] public double Precip { get; set; }
        [JsonProperty("app_temp")] public double AppTemp { get; set; }
        [JsonProperty("temp")] public double Temp { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")] public string Description { get; set; }
    }
}