using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WeatherSample.Models
{
    public static class WeatherExternalModel
    {
        public static Weathers FromJson(
            string json
        ) => JsonConvert.DeserializeObject<Weathers>(json, Settings);

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTime,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }

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
        [JsonProperty("datetime")] public string Datetime { get; set; }
        [JsonProperty("temp")] public double Temp { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")] public string Description { get; set; }
    }
}