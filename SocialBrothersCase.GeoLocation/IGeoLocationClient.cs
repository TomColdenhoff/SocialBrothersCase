using SocialBrothersCase.GeoLocation.ClientResponseModels;

namespace SocialBrothersCase.GeoLocation;

public interface IGeoLocationClient
{
    public Task<Location?> GetLocation(string address);
}