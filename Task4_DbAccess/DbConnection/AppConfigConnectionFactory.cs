using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Task4_DbAccess;

namespace Task4_GUI
{
    public class AppConfigConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory m_provider;
        private readonly string m_connectionString;

        public AppConfigConnectionFactory(string connectionName)
        {
            if (connectionName == null)
            {
                throw new ArgumentNullException("connectionName");
            }

            var connectionString = ConfigurationManager.ConnectionStrings[connectionName];
            if (connectionString == null)
                throw new ConfigurationErrorsException(string.Format("Failed to find connection string '{0}' in app.config.", connectionName));

            m_provider = DbProviderFactories.GetFactory(connectionString.ProviderName);
            m_connectionString = connectionString.ConnectionString;

        }

        public IDbConnection Create()
        {
            var connection = m_provider.CreateConnection();
            if (connection == null)
            {
                throw new ConfigurationErrorsException("Failed to create a connection.");
            }

            connection.ConnectionString = m_connectionString;
            connection.Open();
            return connection;
        }
    }
}
