using MediatR;

namespace SocialBrothersCase.API.Commands;

public class DeleteAddressCommand : IRequest<bool>
{
    public readonly Guid AddressId;

    public DeleteAddressCommand(Guid addressId)
    {
        AddressId = addressId;
    }
}