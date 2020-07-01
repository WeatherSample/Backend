using System.Threading.Tasks;
using WeatherSample.Dal.Abstract.Base;
using WeatherSample.Entities;

namespace WeatherSample.Dal.Abstract
{
    public interface IWeatherRepository : IGenericKeyRepository<string, CityEntity>
    {
        public Task Replace(CityEntity? city);
    }
}