using Serilog;

namespace WeatherSample.Logger
{
    public static class Logger
    {
        private const string Pattern =
            "{Timestamp:HH:mm:ss.fff} [{Level:u3}][{SourceContext:l}][{NDC:l}]({ThreadId}) {Message}{NewLine}{Exception:l}";

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole(outputTemplate: Pattern)
                .CreateLogger();
        }
    }
}