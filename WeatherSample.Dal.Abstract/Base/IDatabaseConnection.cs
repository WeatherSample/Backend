namespace WeatherSample.Dal.Abstract.Base
{
    /// <summary>
    /// Base interface for data base connection.
    /// Basically used for linq2db connection configuring,
    /// probably by using EF it will not needed.
    /// </summary>
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Do configure connection with data base.
        /// </summary>
        public void ConfigureConnection();
    }
}