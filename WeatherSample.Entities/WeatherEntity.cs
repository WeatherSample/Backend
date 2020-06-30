using System;

namespace WeatherSample.Entities
{
    public class WeatherEntity
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = null!;
        public string City { get; set; } = null!;
        public int UvIndex { get; set; } = 0;
        public double Precipitation { get; set; } = 0.0;
        public int Temperature { get; set; } = -1;
        public int TemperatureAsFarenheit => Temperature * 9 / 5 + 32;
        public int ApparentTemperature { get; set; } = -1;
        public int ApparentTemperatureAsFarenheit => ApparentTemperature * 9 / 5 + 32;
    }
}