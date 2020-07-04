using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using WeatherSample.Dal.Abstract;
using WeatherSample.Dal.Impl.MySql.Repository.linq2db.Base;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Impl.MySql.Repository.linq2db
{
    public class WeatherRepository : GenericKeyRepository<string, CityEntity>, IWeatherRepository
    {
        public WeatherRepository() : base("WeatherData")
        {
        }

        public async Task<List<CityEntity>> GetSavedCities() => await GetAllAsync();

        public override async Task<CityEntity?> GetByIdAsync(string id) =>
            await EntityTableContext
                .LoadWith(entity => entity.Data)
                .FirstOrDefaultAsync(entity => entity.CityName == id);

        public override async Task<List<CityEntity>> GetAllAsync() =>
            await EntityTableContext.LoadWith(entity => entity.Data).ToListAsync();

        public override async Task<CityEntity> AddAsync(CityEntity entity)
        {
            await EntityTableContext.DataContext.InsertAsync(entity);
            foreach (var forecast in entity.Data)
            {
                forecast.CityName = entity.CityName;
                await EntityTableContext.DataContext.InsertAsync(forecast);
            }

            return entity;
        }

        public override async Task<CityEntity> ReplaceAsync(CityEntity entity)
        {
            await using (var db = new DataConnection())
            {
                try
                {
                    await db.BeginTransactionAsync();
                    await EntityTableContext.DeleteAsync(
                        cityEntity => cityEntity.CityName == entity.CityName
                    );
                    await AddAsync(entity);
                    await db.CommitTransactionAsync();
                    return entity;
                }
                catch
                {
                    await db.RollbackTransactionAsync();
                    throw;
                }
            }
        }
    }
}