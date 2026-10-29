using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShEC.UMS.Infrastructure.Persistence;

namespace ShEC.UMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("ShECUms");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'ShECUms' is not configured.");
        }

        services.AddDbContext<ShECUmsDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
