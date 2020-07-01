using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Abstract.Base
{
    public interface IGenericKeyRepository<in TKey, TEntity> where TEntity : class
    {
        Task<List<CityEntity>> GetCachedCities();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> AddAsync(TEntity? entity);
        Task DeleteAll();
    }
}