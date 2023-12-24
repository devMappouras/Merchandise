using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Sizes;

public record UpdateSizeCommand(
    int SizeId,
    string SizeName,
    string SizeDescription) : IRequest;

public record UpdateSizeRequest(
    string SizeName,
    string SizeDescription);

internal sealed class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand>
{
    private readonly IBaseRepository<Size> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSizeCommandHandler(IBaseRepository<Size> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
    {
        var size = await _repository.GetByIdAsync(request.SizeId)
            ?? throw new NotFoundException(request.SizeId, nameof(Size));

        size.Update(              
            request.SizeName,
            request.SizeDescription);
        _repository.Update(size);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}