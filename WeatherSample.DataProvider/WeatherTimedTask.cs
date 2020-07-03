using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WeatherSample.Dal.Abstract;
using WeatherSample.Entities;
using WeatherSample.Utils.Converters;

namespace WeatherSample.DataProvider
{
    /// <summary>
    /// This class may be removed, just that like example
    /// for interacting with data base, it not a part of test
    /// task.
    ///
    /// Class includes logic for updating cached cities in
    /// database at background as service.
    ///
    /// Just in task you said "save in data base results",
    /// but idk for what? I think just saving results useless,
    /// and I maded it, for using cached results.
    /// </summary>
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

        /// <summary>
        /// Every N seconds do fetch new weather data from
        /// provider and update old enties in data base.
        /// </summary>
        /// <param name="state">idk need it for, lol.</param>
        private async void Action(object state)
        {
            var cached = await _repository.GetSavedCities();
            foreach (var city in cached)
            {
                var updated = await _service.FetchCity(city.CityName);
                CityEntity? external = updated == null ? null : _externalToEntity.Convert(updated);
                if (external != null) await _repository.ReplaceAsync(external);
            }
        }

        public void Dispose() => _timer?.Dispose();
    }
}