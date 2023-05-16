using System.ComponentModel.DataAnnotations;

namespace SocialBrothersCase.AddressDomain;

public class Address
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Street { get; set; }
    
    [Required]
    public int? HouseNumber { get; set; }
    
    public string? Addition { get; set; }
    
    [Required]
    public string Postcode { get; set; }
    
    [Required]
    public string City { get; set; }
    
    [Required]
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{Street} {HouseNumber}{Addition}, {City}, {Country}";
    }
}