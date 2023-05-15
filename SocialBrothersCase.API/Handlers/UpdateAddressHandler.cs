using MediatR;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Commands;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, Address>
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<Address> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        request.Address.Id = request.Id;
        _addressRepository.Update(request.Address);
        await _addressRepository.SaveAsync();

        return request.Address;
    }
}