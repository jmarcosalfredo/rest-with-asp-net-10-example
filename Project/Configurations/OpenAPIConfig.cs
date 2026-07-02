using Microsoft.OpenApi;

namespace rest_with_asp_net_10_example.Configurations;

public static class OpenAPIConfig 
{
    private static readonly string AppName = "RESTful API with ASP.NET 10 Example";
    private static readonly string AppDescription = "RESTful API with ASP.NET 10 Example - A simple example of a RESTful API built with ASP.NET 10.";

    public static IServiceCollection AddOpenApiConfig(this IServiceCollection services)
    {
        services.AddSingleton(new OpenApiInfo
        {
            Title = AppName,
            Version = "v1",
            Description = AppDescription,
            Contact = new OpenApiContact
            {
                Name = "João Marcos",
                Email = "email_de_teste@gmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "MIT",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });
        return services;
    }
}