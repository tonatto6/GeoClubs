using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoClubs.Controllers
{
    [Route("api/clubs")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubsServices clubsServices;

        public ClubsController(IClubsServices clubsServices)
        {
            this.clubsServices = clubsServices;
        }
    }
}
