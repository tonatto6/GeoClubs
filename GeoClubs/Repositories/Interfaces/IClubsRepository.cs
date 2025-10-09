namespace GeoClubs.Repositories.Interfaces
{
    public interface IClubsRepository
    {
        Task<dynamic> SeekAllCoordinates(decimal latitude, decimal longitude, decimal? metersDistance, string? filter);
        Task<dynamic> SeekAll(int? pageNumber, int? rowsPages, string? filter);
        Task<dynamic> Seek(int idClub);
    }
}
