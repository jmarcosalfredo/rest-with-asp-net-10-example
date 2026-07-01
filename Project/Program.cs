using rest_with_asp_net_10_example.Configurations;
using rest_with_asp_net_10_example.Controllers;
using rest_with_asp_net_10_example.Repositories;
using rest_with_asp_net_10_example.Repositories.Impl;
using rest_with_asp_net_10_example.Services;
using rest_with_asp_net_10_example.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IBookServices, BookServicesImpl>();
builder.Services.AddScoped<IPersonServicesV2, PersonServicesImplV2>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
