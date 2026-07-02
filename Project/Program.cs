using rest_with_asp_net_10_example.Configurations;
using rest_with_asp_net_10_example.Controllers;
using rest_with_asp_net_10_example.Repositories;
using rest_with_asp_net_10_example.Repositories.Impl;
using rest_with_asp_net_10_example.Services;
using rest_with_asp_net_10_example.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers().AddContentNegociation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddRouteConfig();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IBookServices, BookServicesImpl>();
builder.Services.AddScoped<IPersonServicesV2, PersonServicesImplV2>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerConfiguration();
app.UseScalarConfiguration();

app.Run();
