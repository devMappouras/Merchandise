using Domain.Exceptions;
using Domain.Entities;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Colors.Delete;

public record DeleteColorCommand(int ColorId) : IRequest;

internal sealed class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand>
{
    private readonly IBaseRepository<Color> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteColorCommandHandler(IBaseRepository<Color> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        var Color = await _repository.GetByIdAsync(request.ColorId);
        if (Color is null)
            throw new NotFoundException(request.ColorId, nameof(Color));

        _repository.Delete(Color);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
