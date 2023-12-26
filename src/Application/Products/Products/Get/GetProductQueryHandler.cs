using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Products.Get;

public record GetProductQuery(int ProductId) : IRequest<ProductResponse>;

public record ProductResponse(
    int ProductId,
    string Name);


internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly MerchantiseDBContext _context;

    public GetProductQueryHandler(MerchantiseDBContext context)
    {
        _context = context;
    }

    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p => p.ProductId == request.ProductId)
            .Select(p => new ProductResponse(
                p.ProductId,
                p.ProductName))
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }
        return product;
    }
}