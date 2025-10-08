using Azure;
using GeoClubs.Models;
using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GeoClubs.Controllers
{
    [Route("api/geoClubs")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubsServices clubsServices;

        public ClubsController(IClubsServices clubsServices)
        {
            this.clubsServices = clubsServices;
        }

        [HttpGet("coordinates")]
        public async Task<IActionResult> getWithCoordinates([FromQuery] decimal latitude
            , [FromQuery,Required] decimal longitude
            , [FromQuery, Required] decimal? metersDistance
            , [FromQuery] string? filter)
        {
            try
            {
                var result = await clubsServices.getWithCoordinates(latitude,longitude,metersDistance,filter);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("address")]
        public async Task<IActionResult> getWithAddress([FromQuery, Required] string address
            , [FromQuery] decimal? metersDistance
            , [FromQuery] string? filter)
        {
            try
            {
                var result = await clubsServices.getWithAddress(address, metersDistance, filter);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
