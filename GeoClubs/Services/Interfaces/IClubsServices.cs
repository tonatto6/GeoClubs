namespace GeoClubs.Services.Interfaces
{
    public interface IClubsServices
    {
        Task<dynamic> SeekAll(decimal latitude, decimal longitude, decimal? metersDistance, string? filter);
    }
}
