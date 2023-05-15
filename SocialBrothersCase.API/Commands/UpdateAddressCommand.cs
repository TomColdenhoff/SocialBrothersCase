using MediatR;
using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.API.Commands;

public class UpdateAddressCommand : IRequest<Address>
{
    public readonly Guid Id;
    
    public readonly Address Address;
    
    public UpdateAddressCommand(Guid id, Address address)
    {
        Id = id;
        Address = address;
    }
}