using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSample.Dal.Abstract.Base;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Abstract
{
    public interface IWeatherRepository : IGenericKeyRepository<string, CityEntity>
    {
        Task<List<CityEntity>> GetSavedCities();
    }
}