using Azure;
using GeoClubs.Models;
using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> SeekAll([FromQuery] decimal latitude
            , [FromQuery] decimal longitude
            , [FromQuery] decimal? metersDistance
            , [FromQuery] string? filter)
        {
            try
            {
                var result = await clubsServices.SeekAll(latitude,longitude,metersDistance,filter);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
