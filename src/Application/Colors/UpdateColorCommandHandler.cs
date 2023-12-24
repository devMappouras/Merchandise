using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Colors.Update;

public record UpdateColorCommand(
    int ColorId,
    string ColorName,
    string ColorCode) : IRequest;

public record UpdateColorRequest(
    string ColorName,
    string ColorCode);

internal sealed class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand>
{
    private readonly IBaseRepository<Color> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateColorCommandHandler(IBaseRepository<Color> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var color = await _repository.GetByIdAsync(request.ColorId)
            ?? throw new NotFoundException(request.ColorId, nameof(Color));

        color.Update(              
            request.ColorName,
            request.ColorCode);
        _repository.Update(color);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}