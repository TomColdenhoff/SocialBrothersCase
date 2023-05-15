using MediatR;
using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.API.Queries;

public class GetAllAddressesQuery : IRequest<List<Address>>
{
    public string? Filter { get; set; }
    
    public string? SortBy { get; set; }
    
    public bool Descending { get; set; }
    
    public GetAllAddressesQuery(string? filter, string? sortBy, bool descending)
    {
        Filter = filter;
        SortBy = sortBy;
        Descending = descending;
    }
}