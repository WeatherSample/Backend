using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherSample.Dal.Abstract.Base
{
    /// <summary>
    /// Base interface for all repositories with specified
    /// type of key and entity data class.
    /// </summary>
    /// <typeparam name="TKey">Type of key in data base.</typeparam>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface IGenericKeyRepository<in TKey, TEntity> where TEntity : class
    {
        /// <returns>Return all enties in data base asynchronously.</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <param name="id">id for getting result by it.</param>
        /// <returns>Returns entity if it present in data base otherwise null.</returns>
        Task<TEntity?> GetByIdAsync(TKey id);

        /// <summary>
        /// Adds entity in data base.
        /// </summary>
        /// <param name="entity">entity data class instance to add.</param>
        /// <returns>If passed entity is null returns null otherwise added entity.</returns>
        Task<TEntity?> AddAsync(TEntity? entity);

        /// <summary>
        /// Do replace old entity to new entity by calling function
        /// insertOrReplace and inherits that behavior.
        /// </summary>
        /// <param name="entity">entity to replace on it.</param>
        /// <returns>passed in argument "entity" entity.</returns>
        Task<TEntity> ReplaceAsync(TEntity entity);

        /// <summary>
        /// Do remove entry in data base matching to
        /// passed argument "entity".
        /// </summary>
        /// <param name="entity">entity to remove.</param>
        /// <returns>removed entity.</returns>
        Task<TEntity> DeleteAsync(TEntity entity);

        /// <summary>
        /// Updates target entity entry in data base.
        /// </summary>
        /// <param name="entity">entity to update.</param>
        /// <returns>affected entries in data base.</returns>
        Task<int> UpdateAsync(TEntity entity);
    }
}