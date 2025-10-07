using Dapper;
using GeoClubs.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace GeoClubs.Repositories
{
    public class ClubsRepository : IClubsRepository
    {
        public async Task<dynamic> SeekAll()
        {
            try
            {
                var parameters = new DynamicParameters();
                //parameters.Add("@Username", username, DbType.String, ParameterDirection.Input);
                //parameters.Add("@UsernameReceiver", userMessage.UsernameReceiver, DbType.String, ParameterDirection.Input);
                //parameters.Add("@Messages", userMessage.Message, DbType.String, ParameterDirection.Input);

                using (var conexion = ConnectionFactory.ConnectionFactory.GetConnection)
                {
                    return await conexion.QueryFirstAsync<dynamic>("usp_UsersMessages_Send",
                                                parameters, null, null, CommandType.StoredProcedure);
                }
            }
            catch (SqlException sqlEx)
            {
                throw new CustomException(sqlEx);
            }
            catch (Exception ex)
            {
                throw new CustomException(422, ex.Message);
            }
        }
    }
}
