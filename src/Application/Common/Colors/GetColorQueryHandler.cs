using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Colors;

public record GetColorQuery(int ColorId) : IRequest<ColorResponse>;

public record ColorResponse(
    int ColorId,
    string ColorName,
    string ColorCode);


internal sealed class GetColorQueryHandler : IRequestHandler<GetColorQuery, ColorResponse>
{
    private readonly MerchantiseDBContext _context;

    public GetColorQueryHandler(MerchantiseDBContext context)
    {
        _context = context;
    }

    public async Task<ColorResponse> Handle(GetColorQuery request, CancellationToken cancellationToken)
    {
        var Color = await _context.Colors
            .Where(p => p.ColorId == request.ColorId)
            .Select(p => new ColorResponse(
                p.ColorId,
                p.ColorName,
                p.ColorCode))
            .FirstOrDefaultAsync(cancellationToken);

        if (Color is null)
        {
            throw new NotFoundException(request.ColorId, nameof(Color));
        }
        return Color;
    }
}