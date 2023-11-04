using Domain.Products;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Get;

public record GetProductQuery(int ProductId) : IRequest<ProductResponse>;

public record ProductResponse(
    int ProductId,
    string Name,
    decimal Price,
    int? Stock);


internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly ApplicationDbContext _context;

    public GetProductQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductResponse(
                p.Id,
                p.Name,
                p.Price,
                p.Stock))
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }
        return product;
    }
}