using Serilog;

namespace rest_with_asp_net_10_example.Configurations;

public static class LoggingConfig
{
    public static void AddSerilogLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Host.UseSerilog();
    }
}