using System;

namespace WeatherSample.Models
{
    public class WeatherModel
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = null!;
        public string City { get; set; } = null!;
        public int UvIndex { get; set; } = 0;
        public double Precipitation { get; set; } = 0.0;
        public int Temperature { get; set; } = -1;
        public int ApparentTemperature { get; set; } = -1;
    }
}