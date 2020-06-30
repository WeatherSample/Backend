using Newtonsoft.Json;

namespace WeatherSample.Models.Serializers
{
    public static class WeatherExternalSerializer
    {
        public static string ToJson(
            this Weathers self
        ) => JsonConvert.SerializeObject(self, Settings);

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore
        };
    }
}