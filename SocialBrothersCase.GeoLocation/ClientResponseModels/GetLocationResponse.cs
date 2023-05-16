using System.Text.Json.Serialization;

namespace SocialBrothersCase.GeoLocation.ClientResponseModels;

public class GetLocationResponse
{
    [JsonPropertyName("data")]
    public Location[] Data { get; set; }
}

public class Location
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}