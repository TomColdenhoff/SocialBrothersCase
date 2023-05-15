using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
}