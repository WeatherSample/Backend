using System.Collections.Generic;
using LinqToDB.Mapping;

namespace WeatherSample.Entities
{
    [Table(Name = "Cities")]
    public class CityEntity
    {
        [Identity, NotNull, Column("id", IsPrimaryKey = true)]
        public int Id { get; set; } = 0;

        [Column, NotNull] public string CityName { get; set; } = string.Empty;

        [
            Association(
                ThisKey = nameof(CityName),
                OtherKey = nameof(Forecast.CityName),
                CanBeNull = false
            ), Column, NotNull
        ]
        public ICollection<Forecast> Data { get; set; } = new List<Forecast>();
    }

    [Table(Name = "Forecast")]
    public class Forecast
    {
        [Column, NotNull] public string CityName { get; set; } = string.Empty;
        [Column, NotNull] public string Description { get; set; } = string.Empty;
        [Column, NotNull] public double Uv { get; set; }
        [Column, NotNull] public double Precip { get; set; }
        [Column, NotNull] public double AppTemp { get; set; }
        [Column, NotNull] public double Temp { get; set; }
        [Column, NotNull] public string LocalTime { get; set; } = string.Empty;
    }
}