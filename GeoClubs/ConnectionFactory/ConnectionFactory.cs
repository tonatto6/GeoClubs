using System.Data.SqlClient;

namespace GeoClubs.ConnectionFactory
{
    public static class ConnectionFactory
    {
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=Clubs;";

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
