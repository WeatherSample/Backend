using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSample.Dal.Abstract.Base;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Abstract
{
    /// <summary>
    /// Base interface repository for WeatherRepository
    /// implementation.
    /// </summary>
    public interface IWeatherRepository : IGenericKeyRepository<string, CityEntity>
    {
        /// <returns>Saved in data base cities entities.</returns>
        Task<List<CityEntity>> GetSavedCities();
    }
}