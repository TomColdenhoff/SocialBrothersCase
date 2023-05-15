using MediatR;
using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.API.Commands;

public class CreateAddressCommand : IRequest<Address>
{
    public readonly Address Address;

    public CreateAddressCommand(Address address)
    {
        this.Address = address;
    }
}