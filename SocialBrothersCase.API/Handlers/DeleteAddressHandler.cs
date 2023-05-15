using MediatR;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Commands;
using SocialBrothersCase.Database.Repositories;

namespace SocialBrothersCase.API.Handlers;

public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, bool>
{
    private readonly IRepository<Address> _addressRepository;

    public DeleteAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }
    
    public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var deletionPossible = await _addressRepository.DeleteAsync(request.AddressId);
        await _addressRepository.SaveAsync();

        return deletionPossible;
    }
}