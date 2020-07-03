using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;
using LinqToDB.DataProvider.MySql;

namespace WeatherSample.Dal.Impl.MySql.Connection
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Name { get; set; } = "WeatherData";
        public string ProviderName { get; set; } = MySqlTools.DetectedProviderName;
        public bool IsGlobal => false;
    }

    public class ConnectionSettings : ILinqToDBSettings
    {
        private readonly string _connectionString;

        public IEnumerable<IDataProviderSettings> DataProviders =>
            Enumerable.Empty<IDataProviderSettings>();

        public ConnectionSettings(string connection) => _connectionString = connection;

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return new ConnectionStringSettings {ConnectionString = _connectionString};
            }
        }

        public string DefaultConfiguration => MySqlTools.DetectedProviderName;
        public string DefaultDataProvider => MySqlTools.DetectedProviderName;
    }
}