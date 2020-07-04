using System.Linq;
using WeatherSample.Entities;
using WeatherSample.Models;

namespace WeatherSample.Utils.Converters
{
    public class ExternalModelToWeatherEntity
    {
        /// <summary>
        /// Converts External (Weather API) model to weather
        /// entity model with the same data.
        /// </summary>
        /// <param name="external">External City data class to convert.</param>
        /// <returns>CityEntity class instance.</returns>
        public CityEntity Convert(WeatherApiModel.Temperatures external)
        {
            var entity = new CityEntity {CityName = external.City.Name};
            foreach (var forecast in external.List)
            {
                entity.Data.Add(
                    new Forecast
                    {
                        Description = forecast.Weather.First().Description,
                        Humidity = forecast.Main.Humidity,
                        Pressure = forecast.Main.Pressure,
                        Temp = forecast.Main.Temp,
                        FeelsLike = forecast.Main.FeelsLike,
                        LocalTime = forecast.DtTxt,
                        TempMax = forecast.Main.TempMax,
                        TempMin = forecast.Main.TempMin,
                        WindSpeed = forecast.Wind.Speed
                    }
                );
            }

            return entity;
        }
    }
}