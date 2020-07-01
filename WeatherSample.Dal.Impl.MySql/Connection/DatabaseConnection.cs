using LinqToDB.Configuration;
using LinqToDB.Data;
using WeatherSample.Dal.Abstract.Base;

namespace WeatherSample.Dal.Impl.MySql.Connection
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly ILinqToDBSettings _settings;
        public DatabaseConnection(ILinqToDBSettings settings) => _settings = settings;
        public void ConfigureConnection() => DataConnection.DefaultSettings = _settings;
    }
}