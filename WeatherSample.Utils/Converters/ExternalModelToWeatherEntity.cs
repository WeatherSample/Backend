using WeatherSample.Entities;
using WeatherSample.Models;
using Forecast = WeatherSample.Entities.Forecast;

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
        public CityEntity? Convert(City? external)
        {
            if (external == null) return null;
            var entity = new CityEntity {CityName = external.CityName};
            foreach (var forecast in external.Data)
            {
                entity.Data.Add(
                    new Forecast
                    {
                        LocalTime = forecast.TimestampLocal,
                        Precip = forecast.Precip,
                        Temp = forecast.Temp,
                        Uv = forecast.Uv,
                        AppTemp = forecast.AppTemp,
                        Description = forecast.Weather.Description
                    }
                );
            }

            return entity;
        }
    }
}