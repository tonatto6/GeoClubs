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
    }
}
