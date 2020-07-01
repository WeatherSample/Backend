using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSample.Models
{
    public class WeatherCities
    {
        [JsonProperty("cities")] public List<City> Cities { get; set; } = new List<City>();
    }

    public class City
    {
        [JsonProperty("name")] public string Name { get; set; } = string.Empty;
    }
}