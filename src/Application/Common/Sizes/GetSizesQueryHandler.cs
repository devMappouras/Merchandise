using Domain.Entities;
using MediatR;

namespace Application.Sizes;

public record GetSizesQuery() : IRequest<IEnumerable<SizeResponse>?>;

internal sealed class GetSizesQueryHandler : IRequestHandler<GetSizesQuery, IEnumerable<SizeResponse>?>
{
    private readonly IBaseRepository<Size> _repository;

    public GetSizesQueryHandler(IBaseRepository<Size> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SizeResponse>?> Handle(GetSizesQuery request, CancellationToken cancellationToken)
    {
        // Mapper usage
        var mapper = new MapperlyMapper();

        var sizes = await _repository.GetAllAsync();
        return mapper.Map(sizes);
    }
}