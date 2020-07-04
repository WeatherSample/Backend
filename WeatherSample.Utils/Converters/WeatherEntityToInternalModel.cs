using WeatherSample.Entities;
using WeatherSample.Models;

namespace WeatherSample.Utils.Converters
{
    public class WeatherEntityToInternalModel
    {
        /// <summary>
        /// Converts entity to internal model (model of response
        /// to clients).
        /// </summary>
        /// <param name="entity">Entity class to convert.</param>
        /// <returns>WeatherInternalModel.City data class instance.</returns>
        public WeatherInternalModel.City Convert(CityEntity entity)
        {
            var weathers = new WeatherInternalModel.City {CityName = entity.CityName};
            foreach (var forecast in entity.Data)
            {
                weathers.Forecasts.Add(new WeatherInternalModel.Forecast
                    {
                        Description = forecast.Description,
                        Humidity = forecast.Humidity,
                        Pressure = forecast.Pressure,
                        Temp = forecast.Temp,
                        FeelsLike = forecast.FeelsLike,
                        LocalTime = forecast.LocalTime,
                        TempMax = forecast.TempMax,
                        TempMin = forecast.TempMin,
                        WindSpeed = forecast.WindSpeed
                    }
                );
            }

            return weathers;
        }
    }
}