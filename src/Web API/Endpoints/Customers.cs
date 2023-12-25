using Application.Customers;
using Carter;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints;

public class Customers : ICarterModule
{
    const string CustomersEndpointsName = "Customers";
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        app.MapPost(CustomersEndpointsName, async (CreateCustomerCommand command, ISender sender) => 
        {
            await sender.Send(command); 
            return Results.Ok();
        });

        app.MapGet("Customers/{id:int}", async (int id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetCustomerQuery(id)));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("Customers", async (ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetCustomersQuery()));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("Customers/{id:int}", async (int id, [FromBody]UpdateCustomerRequest request, ISender sender) =>
        {
            var command = new UpdateCustomerCommand(id,
                request.Email,
                request.Phone,
                request.Name,
                request.LastName);
            await sender.Send(command);
            return Results.NoContent();
        });

        app.MapDelete("Customers/{id:int}", async (int id, ISender sender) => 
        {
            try
            {
                await sender.Send(new DeleteCustomerCommand(id));
                return Results.NoContent();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}