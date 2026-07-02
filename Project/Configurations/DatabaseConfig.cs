using Microsoft.EntityFrameworkCore;
using rest_with_asp_net_10_example.Model.Context;

namespace rest_with_asp_net_10_example.Configurations;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'MSSQLServerSQLConnection:MSSQLServerSQLConnectionString' not found in configuration.");
        }

        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
