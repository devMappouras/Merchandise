using Domain.Entities;
using MediatR;

namespace Application.Products.CategoryGroups;

public record GetCategoryGroupsQuery() : IRequest<IEnumerable<CategoryGroupResponse>?>;

internal sealed class GetCategoryGroupsQueryHandler : IRequestHandler<GetCategoryGroupsQuery, IEnumerable<CategoryGroupResponse>?>
{
    private readonly IBaseRepository<CategoryGroup> _repository;

    public GetCategoryGroupsQueryHandler(IBaseRepository<CategoryGroup> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryGroupResponse>?> Handle(GetCategoryGroupsQuery request, CancellationToken cancellationToken)
    {
        // Mapper usage
        var mapper = new MapperlyMapper();

        var categoryGroups = await _repository.GetAllAsync();
        return mapper.Map(categoryGroups);
    }
}