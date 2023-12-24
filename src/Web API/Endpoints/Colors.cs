using Application.Colors.Create;
using Application.Colors.Delete;
using Application.Colors.Get;
using Application.Colors.Update;
using Carter;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints;

public class Colors : ICarterModule
{
    const string ColorsEmdpointsName = "Colors";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        /// <summary>
        /// Creates a new Color.
        /// </summary>
        app.MapPost(ColorsEmdpointsName, async (CreateColorCommand command, ISender sender) => 
        {
            await sender.Send(command); 
            return Results.Ok();
        });

        app.MapGet("Colors/{id:int}", async (int Id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetColorQuery(Id)));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("Colors", async (ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetColorsQuery()));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("Colors/{id:int}", async (int id, [FromBody]UpdateColorRequest request, ISender sender) =>
        {
            var command = new UpdateColorCommand(id,
                request.ColorName,
                request.ColorCode);
            await sender.Send(command);
            return Results.NoContent();
        });

        app.MapDelete("Colors/{id:int}", async (int id, ISender sender) => 
        {
            try
            {
                await sender.Send(new DeleteColorCommand(id));
                return Results.NoContent();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}