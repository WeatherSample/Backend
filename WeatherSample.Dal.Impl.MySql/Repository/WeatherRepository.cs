using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using WeatherSample.Dal.Abstract;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Impl.MySql.Repository
{
    public class WeatherRepository : DataConnection, IWeatherRepository
    {
        public WeatherRepository() : base("WeatherData")
        {
        }

        public Task<List<CityEntity>> GetCachedCities() => GetTable<CityEntity>().ToListAsync();

        public ITable<CityEntity> Weathers => GetTable<CityEntity>();

        public async Task<CityEntity?> GetByIdAsync(string id) =>
            await Weathers
                .LoadWith(entity => entity.Data)
                .FirstOrDefaultAsync(entity => entity.CityName == id);

        public async Task<CityEntity?> AddAsync(CityEntity? entity)
        {
            if (entity == null) return null;
            await Weathers.InsertAsync(() => entity);
            return entity;
        }

        public async Task Replace(CityEntity? city)
        {
            if (city == null) return;
            await Weathers.Where(entity => entity.CityName == city.CityName).DeleteAsync();
            await AddAsync(city);
        }

        public async Task DeleteAll() => await Weathers.DeleteAsync();
    }
}