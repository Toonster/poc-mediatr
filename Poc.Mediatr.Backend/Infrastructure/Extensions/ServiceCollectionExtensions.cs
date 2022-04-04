using Application.Customers.Queries;
using Application.Transactions;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MediatrPocDb");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("No connection string found, unable to connect to the database");
        }

        services.AddDbContext<MediatrPocDbContext>(
                options => options.UseSqlServer(connectionString)
            );

        services.AddTransient<ICustomerQueries, EfCustomerQueries>();
        services.AddTransient<IUnitOfWork, EfUnitOfWork>();
    }
}