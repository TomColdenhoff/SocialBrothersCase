using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.Database.Configurations;

namespace SocialBrothersCase.Database;

public class AddressContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Address> Addresses { get; set; }

    public AddressContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("sqlite"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AddressEntityTypeConfiguration());
    }
}