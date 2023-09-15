using Domain;
using Domain.Entities.Countries;
using Domain.SeedWork;
using Infrastructure.Domain.Countries;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddAutoMapper(typeof(AppDbContext).Assembly);

        services.AddScoped<ICountryReadRepository, CountryReadRepository>();
        services.AddScoped<ICountryWriteRepository, CountryWriteRepository>();
        services.AddScoped<IReadUnitOfWork, ReadUnitOfWork>();
        services.AddScoped<IWriteUnitOfWork, WriteUnitOfWork>();

        services.AddScoped<ITaxService, CongestionTaxService>();

        services.AddScoped<AppDbContext>();

        services.AddAutoMapper(typeof(AppDbContext).Assembly);
        return services;
    }
}
