using WeatherSample.Entities;
using WeatherSample.Models;

namespace WeatherSample.Utils.Converters
{
    public class WeatherEntityToInternalModel
    {
        public WeatherInternalModel.City? Convert(CityEntity? entity)
        {
            if (entity == null) return null;
            var weathers = new WeatherInternalModel.City {CityName = entity.CityName};
            foreach (var forecast in entity.Data)
            {
                weathers.Data.Add(new WeatherInternalModel.Forecast
                    {
                        Datetime = forecast.Datetime,
                        Precip = forecast.Precip,
                        Temp = forecast.Temp,
                        Uv = forecast.Uv,
                        AppTemp = forecast.AppTemp,
                        ForecastMeta = new WeatherInternalModel.ForecastMeta
                        {
                            Description = forecast.ForecastMeta.Description
                        }
                    }
                );
            }

            return weathers;
        }
    }
}