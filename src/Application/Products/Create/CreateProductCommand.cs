using MediatR;

namespace Application.Products.Create;

public record CreateProductCommand (
    string Name,
    decimal Price,
    int Stock) : IRequest;