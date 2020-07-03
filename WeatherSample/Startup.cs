using LinqToDB.Common;
using LinqToDB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherSample.Dal.Abstract;
using WeatherSample.Dal.Abstract.Base;
using WeatherSample.Dal.Impl.MySql.Connection;
using WeatherSample.Dal.Impl.MySql.Repository.linq2db;
using WeatherSample.DataProvider;
using WeatherSample.Services;
using WeatherSample.Utils.Converters;

namespace WeatherSample
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public readonly DatabaseConnection DbConnection;

        public Startup(IConfiguration configuration)
        {
            Configuration.Linq.AllowMultipleQuery = true;
            Secrets.ConfigureSecrets(configuration);
            DbConnection = new DatabaseConnection(
                new ConnectionSettings(Secrets.ConnectionString)
            );
            _configuration = configuration;
            DbConnection.ConfigureConnection();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ExternalModelToWeatherEntity>();
            services.AddSingleton<WeatherEntityToInternalModel>();
            services.AddSingleton<WeatherDataFetchService>();
            services.AddSingleton(provider =>
                new WeatherExternalApiService(Secrets.WeatherServiceToken)
            );

            services.AddTransient<IWeatherRepository, WeatherRepository>();
            services.AddTransient<ILinqToDBSettings, ConnectionSettings>(
                provider => new ConnectionSettings(Secrets.ConnectionString)
            );
            services.AddTransient<IDatabaseConnection, DatabaseConnection>(
                provider => DbConnection
            );
            services.AddHostedService<WeatherTimedTask>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}