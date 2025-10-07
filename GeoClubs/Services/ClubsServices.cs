using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services.Interfaces;

namespace GeoClubs.Services
{
    public class ClubsServices : IClubsServices
    {
        private readonly IClubsRepository clubsRepository;

        public ClubsServices(IClubsRepository clubsRepository)
        {
            this.clubsRepository = clubsRepository;
        }

        public async Task<dynamic> SeekAll(decimal latitude, decimal longitude, decimal? metersDistance, string? filter)
        {
            return await clubsRepository.SeekAll(latitude, longitude, metersDistance, filter);
        }
    }
}
