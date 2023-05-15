using MediatR;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Queries;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class GetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, List<Address>>
{
    private readonly IRepository<Address> _addressRepository;

    public GetAllAddressesHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<List<Address>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var addresses = await _addressRepository.GetAsync(request.Filter, request.SortBy, request.Descending, "");
        return addresses.ToList();
    }
}