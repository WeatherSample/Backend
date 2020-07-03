using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSample.Models
{
    public class City
    {
        [JsonProperty("data")] public List<Datum> Data { get; set; } = new List<Datum>();
        [JsonProperty("city_name")] public string CityName { get; set; } = string.Empty;
    }

    public class Datum
    {
        [JsonProperty("weather")] public Weather Weather { get; set; } = new Weather();
        [JsonProperty("uv")] public double Uv { get; set; }
        [JsonProperty("precip")] public double Precip { get; set; }
        [JsonProperty("app_temp")] public double AppTemp { get; set; }
        [JsonProperty("temp")] public double Temp { get; set; }
        [JsonProperty("timestamp_local")] public string TimestampLocal { get; set; } = string.Empty;
    }

    public class Weather
    {
        [JsonProperty("description")] public string Description { get; set; } = string.Empty;
    }
}