using Application;
using Infrastructure;
using Serilog;
using Infrastructure.DataAccess;
using Domain.Products;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Merchandise API", Version = "v1" });
});

var configuration = builder.Configuration;
builder.Services
    .AddApplication()
    .AddInfrastructure(configuration);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Merchandise API v1");
    });
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.MapCarter();

app.Run();

//CRUD REST API With Clean Architecture & DDD
//videos followed:
//https://www.youtube.com/watch?v=fe4iuaoxGbA
//https://www.youtube.com/watch?v=nE2MjN54few