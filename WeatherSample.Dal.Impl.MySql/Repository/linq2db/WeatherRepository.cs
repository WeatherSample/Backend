using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToDB;
using WeatherSample.Dal.Abstract;
using WeatherSample.Dal.Impl.MySql.Repository.linq2db.Base;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Impl.MySql.Repository.linq2db
{
    public class WeatherRepository : GenericKeyRepository<string, CityEntity>, IWeatherRepository
    {
        public override async Task<CityEntity?> GetByIdAsync(string id) =>
            await EntityTableContext
                .LoadWith(entity => entity.Data)
                .FirstOrDefaultAsync(entity => entity.CityName == id);

        public async Task<List<CityEntity>> GetSavedCities() =>
            await EntityTableContext.ToListAsync();
    }
}