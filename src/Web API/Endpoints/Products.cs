using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Carter;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints;

public class Products : ICarterModule
{
    const string ProductsEndpointsName = "products";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        app.MapPost(ProductsEndpointsName, async (CreateProductCommand command, ISender sender) => 
        {
            await sender.Send(command); 
            return Results.Ok();
        });

        app.MapGet("products/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProductQuery(id)));
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("products/{id:int}", async (int id, [FromBody]UpdateProductRequest request, ISender sender) =>
        {
            var command = new UpdateProductCommand(id,
                request.ProductName,
                request.Description,
                request.Price,
                request.DiscountId,
                request.CategoryId,
                request.ManufacturerId,
                request.InventoryId);
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