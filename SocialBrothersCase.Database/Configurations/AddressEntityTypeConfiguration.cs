using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialBrothersCase.AddressDomain;

namespace SocialBrothersCase.Database.Configurations;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasData(new Address[]
        {
            new Address()
            {
                Id = Guid.NewGuid(),
                Street = "Sparrendreef",
                HouseNumber = 43,
                Addition = "A",
                Postcode = "4132 XX",
                City = "Vianen",
                Country = "Nederland"
            },
            new Address()
            {
                Id = Guid.NewGuid(),
                Street = "Orteliuslaan",
                HouseNumber = 1000,
                Addition = null,
                Postcode = "3528 BD",
                City = "Utrecht",
                Country = "Nederland"
            },
        });
    }
}