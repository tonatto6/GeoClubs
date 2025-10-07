using Dapper;
using GeoClubs.Models;
using GeoClubs.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace GeoClubs.Repositories
{
    public class ClubsRepository : IClubsRepository
    {
        public async Task<dynamic> SeekAll(decimal latitude,decimal longitude,decimal? metersDistance,string? filter)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Latitude", latitude, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@Longitude", longitude, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@MetersDistance", metersDistance, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@Filter", filter, DbType.String, ParameterDirection.Input);

                using (var conexion = ConnectionFactory.ConnectionFactory.GetConnection)
                {
                    return await conexion.QueryAsync<dynamic>("usp_Clubs_SeekAll",
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
