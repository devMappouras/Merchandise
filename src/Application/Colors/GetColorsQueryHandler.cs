using Domain.Entities;
using MediatR;

namespace Application.Colors.Get;

public record GetColorsQuery() : IRequest<IEnumerable<ColorResponse>?>;

internal sealed class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IEnumerable<ColorResponse>?>
{
    private readonly IBaseRepository<Color> _repository;

    public GetColorsQueryHandler(IBaseRepository<Color> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ColorResponse>?> Handle(GetColorsQuery request, CancellationToken cancellationToken)
    {
        // Mapper usage
        var mapper = new MapperlyMapper();

        var colors = await _repository.GetAllAsync();
        return mapper.Map(colors);
    }
}