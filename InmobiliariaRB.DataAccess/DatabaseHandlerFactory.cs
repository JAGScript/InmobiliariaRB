using System.Configuration;

namespace InmobiliariaRB.DataAccess
{
    public class DatabaseHandlerFactory
    {
        private ConnectionStringSettings connectionStringSettings;

        public DatabaseHandlerFactory(string connectionStringName)
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler database = new SqlDataAccess(connectionStringSettings.ConnectionString);

            return database;
        }
    }
}
