using MediatR;

namespace Application.Products.Update;

public record UpdateProductCommand(
    int ProductId,
    string Name,
    decimal Price,
    int Stock) : IRequest;

public record UpdaterProductRequest(
    int ProductId,
    string Name,
    decimal Price,
    int Stock);