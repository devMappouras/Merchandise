using Application.Sizes;
using Carter;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints;

public class Sizes : ICarterModule
{
    const string SizesEndpointsName = "Sizes";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        /// <summary>
        /// Creates a new Size.
        /// </summary>
        app.MapPost(SizesEndpointsName, async (CreateSizeCommand command, ISender sender) => 
        {
            await sender.Send(command); 
            return Results.Ok();
        });

        app.MapGet("Sizes/{id:int}", async (int Id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetSizeQuery(Id)));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("Sizes", async (ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetSizesQuery()));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("Sizes/{id:int}", async (int id, [FromBody]UpdateSizeRequest request, ISender sender) =>
        {
            var command = new UpdateSizeCommand(id,
                request.SizeName,
                request.SizeDescription);
            await sender.Send(command);
            return Results.NoContent();
        });

        app.MapDelete("Sizes/{id:int}", async (int id, ISender sender) => 
        {
            try
            {
                await sender.Send(new DeleteSizeCommand(id));
                return Results.NoContent();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}