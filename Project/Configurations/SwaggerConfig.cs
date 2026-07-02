using Microsoft.OpenApi;


namespace rest_with_asp_net_10_example.Configurations;

public static class SwaggerConfig 
{
    private static readonly string AppName = "RESTful API with ASP.NET 10 Example";
    private static readonly string AppDescription = "RESTful API with ASP.NET 10 Example - A simple example of a RESTful API built with ASP.NET 10.";

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "João Marcos",
                    Email = "email_de_teste@gmail.com",
                }
            });
            options.CustomSchemaIds(type => type.FullName);

        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = "swagger-ui";
            options.DocumentTitle = AppName;
        });
        return app;
    }
}