using MediatR;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Queries;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, Address?>
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressByIdHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<Address?> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        return await _addressRepository.GetByIdAsync(request.Id);
    }
}