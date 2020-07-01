using WeatherSample.Entities;
using WeatherSample.Models;
using Forecast = WeatherSample.Entities.Forecast;
using ForecastMeta = WeatherSample.Entities.ForecastMeta;

namespace WeatherSample.Utils.Converters
{
    public class ExternalModelToWeatherEntity
    {
        public CityEntity? Convert(City? external)
        {
            if (external == null) return null;
            var entity = new CityEntity {CityName = external.CityName};
            foreach (var forecast in external.Data)
            {
                entity.Data.Add(new Forecast
                    {
                        Datetime = forecast.Datetime,
                        Precip = forecast.Precip,
                        Temp = forecast.Temp,
                        Uv = forecast.Uv,
                        AppTemp = forecast.AppTemp,
                        ForecastMeta = new ForecastMeta
                        {
                            Description = forecast.ForecastMeta.Description
                        }
                    }
                );
            }

            return entity;
        }
    }
}