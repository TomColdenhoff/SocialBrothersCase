using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.GeoLocation;
using SocialBrothersCase.GeoLocation.ClientResponseModels;

namespace SocialBrothersCase.AddressApplication;

public class AddressService : IAddressService
{
    private readonly IGeoLocationClient _locationClient;

    public AddressService(IGeoLocationClient locationClient)
    {
        _locationClient = locationClient;
    }
    
    public async Task<double> CalculateDistanceInKm(Address from, Address to)
    {
        var locationFrom = await _locationClient.GetLocation(from.ToString());
        var locationTo = await _locationClient.GetLocation(to.ToString());

        if (locationFrom == null || locationTo == null)
        {
            return 0;
        }

        var distance = CalculateDistanceBetweenCoordinates(locationFrom, locationTo);

        return distance;
    }

    private double CalculateDistanceBetweenCoordinates(Location locationA, Location locationB)
    {
        //https://www.movable-type.co.uk/scripts/latlong.html
        const double radius = 6371e3;
        var latARadians = locationA.Latitude * Math.PI/180;
        var latBRadians = locationB.Latitude * Math.PI/180;
        var deltaLatRad = (locationA.Latitude - locationB.Latitude) * Math.PI / 180;
        var deltaLongRad = (locationA.Longitude - locationB.Longitude) * Math.PI / 180;
        
        var a = Math.Sin(deltaLatRad/2) * Math.Sin(deltaLatRad/2) +
                Math.Cos(latARadians) * Math.Cos(latBRadians) *
                Math.Sin(deltaLongRad/2) * Math.Sin(deltaLongRad/2);
        
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
        var distance = radius * c;

        return distance / 1000; // Meter to KM
    }
    
}