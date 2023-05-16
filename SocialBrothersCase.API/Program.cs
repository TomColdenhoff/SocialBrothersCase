using System.Reflection;
using SocialBrothersCase.AddressApplication;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.Database;
using SocialBrothersCase.Database.Repositories;
using SocialBrothersCase.GeoLocation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AddressContext>();
builder.Services.AddScoped<IRepository<Address>, GenericRepository<Address>>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddGeoLocation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();