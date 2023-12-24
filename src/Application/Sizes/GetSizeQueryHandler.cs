using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sizes;

public record GetSizeQuery(int SizeId) : IRequest<SizeResponse>;

public record SizeResponse(
    int SizeId,
    string SizeName,
    string SizeDescription);


internal sealed class GetSizeQueryHandler : IRequestHandler<GetSizeQuery, SizeResponse>
{
    private readonly MerchantiseDBContext _context;

    public GetSizeQueryHandler(MerchantiseDBContext context)
    {
        _context = context;
    }

    public async Task<SizeResponse> Handle(GetSizeQuery request, CancellationToken cancellationToken)
    {
        var size = await _context.Sizes
            .Where(p => p.SizeId == request.SizeId)
            .Select(p => new SizeResponse(
                p.SizeId,
                p.SizeName,
                p.SizeDescription))
            .FirstOrDefaultAsync(cancellationToken);

        if (size is null)
        {
            throw new NotFoundException(request.SizeId, nameof(size));
        }
        return size;
    }
}