using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Sizes;

public record DeleteSizeCommand(int SizeId) : IRequest;

internal sealed class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand>
{
    private readonly IBaseRepository<Size> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSizeCommandHandler(IBaseRepository<Size> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
    {
        var Size = await _repository.GetByIdAsync(request.SizeId);
        if (Size is null)
            throw new NotFoundException(request.SizeId, nameof(Size));

        _repository.Delete(Size);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
