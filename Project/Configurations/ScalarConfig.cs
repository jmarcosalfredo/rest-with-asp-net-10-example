using Scalar.AspNetCore;

namespace rest_with_asp_net_10_example.Configurations;
public static class ScalarConfig
{
    private static readonly string AppName = "RESTful API with ASP.NET 10 Example";
    private static readonly string AppDescription = "RESTful API with ASP.NET 10 Example - A simple example of a RESTful API built with ASP.NET 10.";


    public static WebApplication UseScalarConfiguration(this WebApplication app)
    {
        app.MapScalarApiReference("/scalar", options =>
        {
            options.WithTitle(AppName);
            options.WithOpenApiRoutePattern("/swagger/v1/swagger.json");
        });

        return app;
    }
    
}