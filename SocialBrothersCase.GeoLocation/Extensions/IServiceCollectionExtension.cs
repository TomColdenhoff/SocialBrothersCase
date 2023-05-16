using Microsoft.Extensions.DependencyInjection;
using SocialBrothersCase.GeoLocation.Clients;

namespace SocialBrothersCase.GeoLocation.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddGeoLocation(this IServiceCollection services)
    {
        services.AddHttpClient<IGeoLocationClient, PositionStackGeoLocationClient>();
        return services;
    }
}