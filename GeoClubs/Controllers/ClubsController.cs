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

        [HttpGet("{idClub}")]
        public async Task<IActionResult> Seek(int idClub)
        {
            try
            {
                var result = await clubsServices.Seek(idClub);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SeekAll([FromQuery] int pageNumber
            , [FromQuery] int? rowsPages
            , [FromQuery] string? filter)
        {
            try
            {
                var result = await clubsServices.SeekAll(pageNumber, rowsPages, filter);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("coordinates")]
        public async Task<IActionResult> getWithCoordinates([FromQuery, Required] decimal latitude
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
