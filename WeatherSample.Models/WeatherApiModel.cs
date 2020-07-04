using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * Generated class by https://app.quicktype.io/?l=csharp,
 * from response of https://community-open-weather-map.p.rapidapi.com/forecast.
 */
namespace WeatherSample.Models
{
    public class WeatherApiModel
    {
        public class Temperatures
        {
            [JsonProperty("list")] public List<List> List { get; set; } = new List<List>();
            [JsonProperty("city")] public City City { get; set; } = new City();
        }

        public class City
        {
            [JsonProperty("name")] public string Name { get; set; } = string.Empty;
        }

        public class List
        {
            [JsonProperty("main")] public MainClass Main { get; set; } = new MainClass();

            [JsonProperty("weather")]
            public List<Weather> Weather { get; set; } = new List<Weather>();

            [JsonProperty("wind")] public Wind Wind { get; set; } = new Wind();
            [JsonProperty("dt_txt")] public string DtTxt { get; set; } = string.Empty;
        }

        public class MainClass
        {
            [JsonProperty("temp")] public double Temp { get; set; }
            [JsonProperty("feels_like")] public double FeelsLike { get; set; }
            [JsonProperty("temp_min")] public double TempMin { get; set; }
            [JsonProperty("temp_max")] public double TempMax { get; set; }
            [JsonProperty("pressure")] public long Pressure { get; set; }
            [JsonProperty("humidity")] public long Humidity { get; set; }
        }

        public class Weather
        {
            [JsonProperty("description")] public string Description { get; set; } = string.Empty;
        }

        public class Wind
        {
            [JsonProperty("speed")] public double Speed { get; set; }
        }
    }
}