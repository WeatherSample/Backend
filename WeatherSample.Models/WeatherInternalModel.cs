using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSample.Models
{
    public class WeatherInternalModel
    {
        public class City
        {
            [JsonProperty("city_name")] public string CityName { get; set; } = string.Empty;
            [JsonProperty("data")] public List<Forecast> Data { get; set; } = new List<Forecast>();
        }

        public class Forecast
        {
            [JsonProperty("description")] public string Description { get; set; } = string.Empty;
            [JsonProperty("uv")] public double Uv { get; set; }
            [JsonProperty("precip")] public double Precip { get; set; }
            [JsonProperty("app_temp")] public double AppTemp { get; set; }
            [JsonProperty("temp")] public double Temp { get; set; }
            [JsonProperty("local_time")] public string LocalTime { get; set; } = string.Empty;
        }
    }
}