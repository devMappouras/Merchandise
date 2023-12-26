using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.CategoryGroups;

public record GetCategoryGroupQuery(int CategoryGroupId) : IRequest<CategoryGroupResponse>;

public record CategoryGroupResponse(
    int GroupId,
    string GroupName);


internal sealed class GetCategoryGroupQueryHandler : IRequestHandler<GetCategoryGroupQuery, CategoryGroupResponse>
{
    private readonly MerchantiseDBContext _context;

    public GetCategoryGroupQueryHandler(MerchantiseDBContext context)
    {
        _context = context;
    }

    public async Task<CategoryGroupResponse> Handle(GetCategoryGroupQuery request, CancellationToken cancellationToken)
    {
        var categoryGroup = await _context.CategoryGroups
            .Where(p => p.GroupId == request.CategoryGroupId)
            .Select(p => new CategoryGroupResponse(
                p.GroupId,
                p.GroupName))
            .FirstOrDefaultAsync(cancellationToken);

        if (categoryGroup is null)
        {
            throw new NotFoundException(request.CategoryGroupId, nameof(CategoryGroup));
        }
        return categoryGroup;
    }
}