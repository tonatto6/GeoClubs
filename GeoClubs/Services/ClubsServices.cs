using GeoClubs.Helpers;
using GeoClubs.Models;
using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services.Interfaces;

namespace GeoClubs.Services
{
    public class ClubsServices : IClubsServices
    {
        private readonly IClubsRepository clubsRepository;
        private readonly HttpClient _httpClient;

        public ClubsServices(IClubsRepository clubsRepository, HttpClient httpClient)
        {
            this.clubsRepository = clubsRepository;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(GetConfigSection.GetConfigValue("urlGetcoordinates").Value)
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GeoClubsApp");
        }

        public async Task<dynamic> getWithCoordinates(decimal latitude, decimal longitude, decimal? metersDistance, string? filter)
        {
            return await clubsRepository.SeekAllCoordinates(latitude, longitude, metersDistance, filter);
        }

        public async Task<dynamic> getWithAddress(string address, decimal? metersDistance, string? filter)
        {
            var url = $"search?format=json&q={Uri.EscapeDataString(address)}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) 
                return null;

            var contenido = await response.Content.ReadFromJsonAsync<List<Coordinates>>();

            if (contenido == null || !contenido.Any())
                return null;

            var latitude = Convert.ToDecimal(contenido[0].Lat, System.Globalization.CultureInfo.InvariantCulture);
            var longitude = Convert.ToDecimal(contenido[0].Lon, System.Globalization.CultureInfo.InvariantCulture);

            return await clubsRepository.SeekAllCoordinates(latitude, longitude, metersDistance, filter);
        }

        public async Task<dynamic> SeekAll(int? pageNumber, int? rowsPages, string? filter)
        {
            return await clubsRepository.SeekAll(pageNumber, rowsPages, filter);
        }

        public async Task<dynamic> Seek(int idClub)
        {
            return await clubsRepository.Seek(idClub);
        }
    }
}
