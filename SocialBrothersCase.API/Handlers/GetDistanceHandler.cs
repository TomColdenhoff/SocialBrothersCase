using MediatR;
using SocialBrothersCase.AddressApplication;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Queries;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class GetDistanceHandler : IRequestHandler<GetDistanceQuery, double?>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IAddressService _addressService;

    public GetDistanceHandler(IRepository<Address> addressRepository, IAddressService addressService)
    {
        _addressRepository = addressRepository;
        _addressService = addressService;
    }

    public async Task<double?> Handle(GetDistanceQuery request, CancellationToken cancellationToken)
    {
        var addressTo = await _addressRepository.GetByIdAsync(request.AddressToId);
        var addressFrom = await _addressRepository.GetByIdAsync(request.AddressFromId);

        if (addressTo == null || addressFrom == null)
        {
            return null;
        }

        var distance = await _addressService.CalculateDistanceInKm(addressTo, addressFrom);

        return distance;
    }
}