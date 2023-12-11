using Domain.Colors;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Colors.Update;

public record UpdateColorCommand(
    int ColorId,
    string ColorName,
    string Description,
    decimal Price,
    int DiscountId,
    int CategoryId,
    int? ManufacturerId,
    int? InventoryId) : IRequest;

public record UpdateColorRequest(
    string ColorName,
    string Description,
    decimal Price,
    int DiscountId,
    int CategoryId,
    int? ManufacturerId,
    int? InventoryId);

internal sealed class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand>
{
    private readonly IColorRepository _ColorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateColorCommandHandler(IColorRepository ColorRepository, IUnitOfWork unitOfWork)
    {
        _ColorRepository = ColorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var Color = await _ColorRepository.GetByIdAsync(request.ColorId)
            ?? throw new ColorNotFoundException(request.ColorId);

        Color.Update(              
            request.ColorName,
            request.Description,
            request.Price,
            request.DiscountId,
            request.CategoryId,
            request.ManufacturerId,
            request.InventoryId);
        _ColorRepository.Update(Color);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}