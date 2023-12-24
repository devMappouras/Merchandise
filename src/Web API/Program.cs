using Application;
using Infrastructure;
using Serilog;
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using Carter;
using Domain.Repositories;
using Web_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();
builder.Services.AddCarter();

var configuration = builder.Configuration;
builder.Services
    .AddApplication()
    .AddInfrastructure(configuration);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web_API v1");
        //c.RoutePrefix = string.Empty;
    });
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.MapSwagger();

app.MapCarter();

app.Run();

//CRUD REST API With Clean Architecture & DDD
//videos followed:
//https://www.youtube.com/watch?v=fe4iuaoxGbA
//https://www.youtube.com/watch?v=nE2MjN54few