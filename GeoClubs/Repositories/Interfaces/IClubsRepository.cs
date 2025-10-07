namespace GeoClubs.Repositories.Interfaces
{
    public interface IClubsRepository
    {
        Task<dynamic> SeekAll(decimal latitude, decimal longitude, decimal? metersDistance, string? filter);
    }
}
