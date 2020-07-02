using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherSample.Dal.Abstract.Base
{
    public interface IGenericKeyRepository<in TKey, TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> AddAsync(TEntity? entity);
        Task<TEntity> ReplaceAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}