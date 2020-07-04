using System.Threading.Tasks;
using WeatherSample.Dal.Abstract;
using WeatherSample.DataProvider;
using WeatherSample.Models;
using WeatherSample.Utils.Converters;

namespace WeatherSample.Services
{
    /// <summary>
    /// Class services as layer for access to cached
    /// and remote data.
    /// </summary>
    public class WeatherDataFetchService
    {
        private readonly IWeatherRepository _repository;
        private readonly WeatherExternalApiService _external;
        private readonly ExternalModelToWeatherEntity _externalToEntity;
        private readonly WeatherEntityToInternalModel _entityToInternal;

        public WeatherDataFetchService(
            IWeatherRepository repository,
            WeatherExternalApiService external,
            ExternalModelToWeatherEntity externalToEntity,
            WeatherEntityToInternalModel entityToInternal
        )
        {
            _repository = repository;
            _external = external;
            _externalToEntity = externalToEntity;
            _entityToInternal = entityToInternal;
        }

        /// <summary>
        /// Returns city if exist in data base or in remote server.
        /// <br/>
        /// Covered cases:
        /// <br/>
        ///  - If city in data base not exist will returned result from server.
        /// <br/>
        ///  - If city in data base exist will returned result from data base.
        /// <br/>
        ///  - If city not exist in any source will returned null.
        /// </summary>
        /// <param name="id">id of city, in this case it's name of city.</param>
        /// <returns>
        /// Null if city not exist, otherwise WeatherInternalModel.City model.
        /// </returns>
        public async Task<WeatherInternalModel.City?> GetByIdAsync(string id)
        {
            var data = await _external.FetchCity(id);
            if (data == null) return null;
            return _entityToInternal.Convert(
                await _repository.GetByIdAsync(id) ??
                await _repository.AddAsync(_externalToEntity.Convert(data))
            );
        }
    }
}