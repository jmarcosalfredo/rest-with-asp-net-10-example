using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace rest_with_asp_net_10_example.Configurations;

public static class EvolveConfig
{

    public static IServiceCollection AddEvolveConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'MSSQLServerSQLConnection:MSSQLServerSQLConnectionString' not found in configuration.");
            }

            try
            {
                using var evolveConnection = new SqlConnection(connectionString);
                var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while migrating the database!");
                throw;
            }
        }


        return services;
    }
}
