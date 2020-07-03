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
        public WeatherInternalModel.City? Convert(CityEntity? entity)
        {
            if (entity == null) return null;
            var weathers = new WeatherInternalModel.City {CityName = entity.CityName};
            foreach (var forecast in entity.Data)
            {
                weathers.Data.Add(new WeatherInternalModel.Forecast
                    {
                        LocalTime = forecast.LocalTime,
                        Precip = forecast.Precip,
                        Temp = forecast.Temp,
                        Uv = forecast.Uv,
                        AppTemp = forecast.AppTemp,
                        Description = forecast.Description
                    }
                );
            }

            return weathers;
        }
    }
}