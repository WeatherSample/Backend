using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using WeatherSample.Dal.Abstract.Base;

namespace WeatherSample.Dal.Impl.MySql.Repository.linq2db.Base
{
    public abstract class GenericKeyRepository<TKey, TEntity>
        : DataConnection, IGenericKeyRepository<TKey, TEntity> where TEntity : class
    {
        public ITable<TEntity> EntityTableContext => GetTable<TEntity>();

        protected GenericKeyRepository()
        {
            TurnTraceSwitchOn();
            WriteTraceLine = (s, s1) => Console.Out.WriteLine(s, s1);
            EntityTableContext.DataContext.CreateTable<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAllAsync() =>
            await EntityTableContext.ToListAsync();

        public abstract Task<TEntity?> GetByIdAsync(TKey id);

        public virtual async Task<TEntity?> AddAsync(TEntity? entity)
        {
            if (entity == null) return null;
            await EntityTableContext.InsertAsync(() => entity);
            return entity;
        }

        public virtual async Task<TEntity> ReplaceAsync(TEntity entity)
        {
            await EntityTableContext.DataContext.InsertOrReplaceAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await EntityTableContext.DataContext.DeleteAsync(entity);
            return entity;
        }

        public virtual async Task<int> UpdateAsync(TEntity entity) =>
            await EntityTableContext.DataContext.UpdateAsync(entity);
    }
}