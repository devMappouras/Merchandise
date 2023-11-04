﻿using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Carter;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints;

public class Products : ICarterModule
{
    const string ProductsEmdpointsName = "products";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        app.MapPost(ProductsEmdpointsName, async (CreateProductCommand command, ISender sender) => 
        {
            await sender.Send(command); 
            return Results.Ok();
        });

        app.MapGet("products/{id:int}", async (int Id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProductQuery(Id)));
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("products/{id:int}", async (int id, [FromBody]UpdaterProductRequest request, ISender sender) =>
        {
            var command = new UpdateProductCommand(id, request.Name, request.Price, request.Stock);
            await sender.Send(command);
            return Results.NoContent();
        });

        app.MapDelete("products/{id:int}", async (int id, ISender sender) => 
        {
            try
            {
                await sender.Send(new DeleteProductCommand(id));
                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}