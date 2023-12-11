using Domain.Colors;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Colors.Delete;

public record DeleteColorCommand(int ColorId) : IRequest;

internal sealed class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand>
{
    private readonly IColorRepository _ColorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteColorCommandHandler(IColorRepository ColorRepository, IUnitOfWork unitOfWork)
    {
        _ColorRepository = ColorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
    {
        var Color = await _ColorRepository.GetByIdAsync(request.ColorId);
        if (Color is null)
            throw new ColorNotFoundException(request.ColorId);

        _ColorRepository.Delete(Color);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
