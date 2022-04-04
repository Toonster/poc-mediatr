using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MediatrPocDb"];

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("No connection string found, unable to connect to the database");
        }

        services.AddDbContext<MediatrPocDbContext>(
                options => options.UseSqlServer(connectionString)
            );
    }
}