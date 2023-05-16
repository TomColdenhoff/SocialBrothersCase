using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SocialBrothersCase.GeoLocation.ClientResponseModels;

namespace SocialBrothersCase.GeoLocation.Clients;

public class PositionStackGeoLocationClient : IGeoLocationClient
{
    private const string ForwardBaseUrl = "http://api.positionstack.com/v1/forward";

    private readonly HttpClient _client;
    private readonly string _apiKey;
    
    public PositionStackGeoLocationClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _apiKey = configuration.GetSection("GeoKey").Value!;
    }
    
    public async Task<Location?> GetLocation(string address)
    {
        var uriString = $"{ForwardBaseUrl}?access_key={_apiKey}&query={address}";
        var uri = new Uri(uriString);
        var result = await _client.GetAsync(uri);
        var responseContent = await result.Content.ReadAsStringAsync();

        var locationResponse = JsonSerializer.Deserialize<GetLocationResponse>(responseContent);

        return locationResponse?.Data.FirstOrDefault();
    }
}