using MediatR;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Commands;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, Address>
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<Address> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.InsertAsync(request.Address);
        await _addressRepository.SaveAsync();

        return request.Address;
    }
}