using Domain.Entities;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Sizes;

public record CreateSizeCommand(
               string SizeName,
               string SizeDescription) : IRequest;

public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand>
{
    private readonly IBaseRepository<Size> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSizeCommandHandler(IBaseRepository<Size> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSizeCommand request, CancellationToken cancellationToken)
    {
        var mapper = new MapperlyMapper();

        var size = mapper.Map(request);
        _repository.Add(size);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
