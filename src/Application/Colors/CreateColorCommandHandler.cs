using Domain.Entities;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Colors.Create;

public record CreateColorCommand(
               string ColorName,
               string ColorCode) : IRequest;

public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand>
{
    private readonly IBaseRepository<Color> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateColorCommandHandler(IBaseRepository<Color> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var mapper = new MapperlyMapper();

        var color = mapper.Map(request);
        _repository.Add(color);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
