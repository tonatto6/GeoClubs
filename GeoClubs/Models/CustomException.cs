using System.Data.SqlClient;

namespace GeoClubs.Models
{
    public class CustomException : Exception
    {
        public CustomException() { }

        public CustomException(int statusCode, string error)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public CustomException(SqlException sqlEx)
        {
            StatusCode = GetStatusError(sqlEx.State);
            Error = sqlEx.Message;
        }

        private static int GetStatusError(int status)
        {
            return status switch
            {
                104 => 422,
                105 => 404,
                _ => 500,
            };
        }

        public int StatusCode { get; set; }
        public string Error { get; set; }
    }
}
