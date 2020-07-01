using System.Collections.Generic;
using LinqToDB.Mapping;

namespace WeatherSample.Entities
{
    [Table(Name = "Cities")]
    public class CityEntity
    {
        [PrimaryKey] public string CityName { get; set; } = null!;
        public List<Forecast> Data { get; set; } = null!;
    }

    [Table(Name = "Forecast")]
    public class Forecast
    {
        [Column, NotNull] public ForecastMeta ForecastMeta { get; set; } = null!;
        [Column, NotNull] public double Uv { get; set; }
        [Column, NotNull] public double Precip { get; set; }
        [Column, NotNull] public double AppTemp { get; set; }
        [Column, NotNull] public double Temp { get; set; }
        [Column, NotNull] public string Datetime { get; set; } = null!;
    }

    public class ForecastMeta
    {
        [Column, NotNull] public string Description { get; set; } = null!;
    }
}