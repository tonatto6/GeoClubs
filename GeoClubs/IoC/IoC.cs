using GeoClubs.Repositories;
using GeoClubs.Repositories.Interfaces;
using GeoClubs.Services;
using GeoClubs.Services.Interfaces;

namespace GeoClubs.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClubsRepository, ClubsRepository>();
            services.AddScoped<IClubsServices, ClubsServices>();

            return services;
        }
    }
}
