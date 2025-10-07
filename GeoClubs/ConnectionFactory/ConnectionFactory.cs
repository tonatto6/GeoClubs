using GeoClubs.Helpers;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace GeoClubs.ConnectionFactory
{
    public static class ConnectionFactory
    {
        private static string connectionString = GetConfigSection.GetConfigValue("databaseConnection").Value;
        public static SqlConnection GetConnection
        {
            get
            {
                var sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                return sqlConn;
            }
        }
    }
}
