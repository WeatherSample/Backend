using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WeatherSample.Dal.Abstract;
using WeatherSample.Utils.Converters;

namespace WeatherSample.DataProvider
{
    public class WeatherTimedTask : IHostedService, IDisposable
    {
        private Timer _timer = null!;
        private readonly IConfiguration _configuration;
        private readonly IWeatherRepository _repository;
        private readonly WeatherExternalApiService _service;
        private readonly ExternalModelToWeatherEntity _externalToEntity;

        public WeatherTimedTask(
            IConfiguration configuration,
            IWeatherRepository repository,
            WeatherExternalApiService service,
            ExternalModelToWeatherEntity externalToEntity
        )
        {
            _configuration = configuration;
            _repository = repository;
            _service = service;
            _externalToEntity = externalToEntity;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Action!, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(
                    Convert.ToDouble(_configuration["WeatherAutoFetchPeriod"])
                )
            );
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void Action(object state)
        {
            var cached = await _repository.GetCachedCities();
            foreach (var city in cached)
            {
                var updated = await _service.FetchCity(city.CityName);
                await _repository.Replace(_externalToEntity.Convert(updated));
            }
        }

        public void Dispose() => _timer?.Dispose();
    }
}