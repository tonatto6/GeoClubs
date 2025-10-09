namespace GeoClubs.Services.Interfaces
{
    public interface IClubsServices
    {
        Task<dynamic> getWithCoordinates(decimal latitude, decimal longitude, decimal? metersDistance, string? filter);
        Task<dynamic> getWithAddress(string address, decimal? metersDistance, string? filter);
        Task<dynamic> SeekAll(int? pageNumber, int? rowsPages, string? filter);
    }
}
