using Microsoft.Extensions.Configuration;

namespace WeatherSample
{
    public static class Secrets
    {
        public static string ConnectionString = null!;
        public static string WeatherServiceToken = null!;

        internal static void ConfigureSecrets(IConfiguration configuration)
        {
            ConnectionString = configuration["DBConnectionString"];
            WeatherServiceToken = configuration["WeatherServiceToken"];
        }
    }
}