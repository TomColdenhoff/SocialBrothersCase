using MediatR;

namespace SocialBrothersCase.API.Queries;

public class GetDistanceQuery : IRequest<double?>
{
    public readonly Guid AddressFromId;
    
    public readonly Guid AddressToId;

    public GetDistanceQuery(Guid addressFromId, Guid addressToId)
    {
        AddressFromId = addressFromId;
        AddressToId = addressToId;
    }
}