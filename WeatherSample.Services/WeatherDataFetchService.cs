using System.Threading.Tasks;
using WeatherSample.Dal.Abstract;
using WeatherSample.DataProvider;
using WeatherSample.Models;
using WeatherSample.Utils.Converters;

namespace WeatherSample.Services
{
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

        public async Task<WeatherInternalModel.City?> GetByIdAsync(string id) =>
            _entityToInternal.Convert(
                await _repository.GetByIdAsync(id) ??
                await _repository.AddAsync(
                    _externalToEntity.Convert(await _external.FetchCity(id))
                )
            );
    }
}