using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.AddressApplication;

public interface IAddressService
{
    public Task<double> CalculateDistanceInKm(Address from, Address to);
}