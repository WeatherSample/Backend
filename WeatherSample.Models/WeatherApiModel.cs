using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSample.Models
{
    public class City
    {
        [JsonProperty("data")] public List<Forecast> Data { get; set; } = null!;
        [JsonProperty("city_name")] public string CityName { get; set; } = null!;
    }

    public class Forecast
    {
        [JsonProperty("weather")] public ForecastMeta ForecastMeta { get; set; } = null!;
        [JsonProperty("uv")] public double Uv { get; set; }
        [JsonProperty("precip")] public double Precip { get; set; }
        [JsonProperty("app_temp")] public double AppTemp { get; set; }
        [JsonProperty("temp")] public double Temp { get; set; }
        [JsonProperty("datetime")] public string Datetime { get; set; } = null!;
    }

    public class ForecastMeta
    {
        [JsonProperty("description")] public string Description { get; set; } = null!;
    }
}