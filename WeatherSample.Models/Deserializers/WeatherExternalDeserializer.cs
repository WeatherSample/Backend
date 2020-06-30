using Newtonsoft.Json;

namespace WeatherSample.Models.Deserializers
{
    public class WeatherExternalDeserializer
    {
        public static Weathers FromJson(
            string json
        ) => JsonConvert.DeserializeObject<Weathers>(json, Settings);

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore
        };
    }
}