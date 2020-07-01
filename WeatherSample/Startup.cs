using LinqToDB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherSample.Dal.Abstract;
using WeatherSample.Dal.Abstract.Base;
using WeatherSample.Dal.Impl.MySql.Connection;
using WeatherSample.Dal.Impl.MySql.Repository;
using WeatherSample.DataProvider;
using WeatherSample.Services;
using WeatherSample.Utils.Converters;

namespace WeatherSample
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Secrets.ConfigureSecrets(configuration);
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ExternalModelToWeatherEntity>();
            services.AddSingleton<WeatherEntityToInternalModel>();
            services.AddSingleton<WeatherDataFetchService>();
            services.AddSingleton(
                provider => new WeatherExternalApiService(Secrets.WeatherServiceToken)
            );

            services.AddTransient<IWeatherRepository, WeatherRepository>();
            services.AddTransient<ILinqToDBSettings, ConnectionSettings>(provider =>
                new ConnectionSettings(Secrets.ConnectionString)
            );
            services.AddTransient<IDatabaseConnection, DatabaseConnection>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.ApplicationServices.GetService<IDatabaseConnection>().ConfigureConnection();
        }
    }
}