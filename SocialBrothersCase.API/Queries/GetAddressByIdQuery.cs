using MediatR;
using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.API.Queries;

public class GetAddressByIdQuery : IRequest<Address?>
{
    public readonly Guid Id;
    
    public GetAddressByIdQuery(Guid id)
    {
        Id = id;
    }
}