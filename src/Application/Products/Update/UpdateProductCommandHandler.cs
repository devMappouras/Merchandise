using Domain.Exceptions;
using Domain.Repositories;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.Update;

public record UpdateProductCommand(
    int ProductId,
    string ProductName,
    string Description,
    decimal Price,
    int DiscountId,
    int CategoryId,
    int? ManufacturerId,
    int? InventoryId) : IRequest;

public record UpdateProductRequest(
    string ProductName,
    string Description,
    decimal Price,
    int DiscountId,
    int CategoryId,
    int? ManufacturerId,
    int? InventoryId);

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId)
            ?? throw new ProductNotFoundException(request.ProductId);

        product.Update(              
            request.ProductName,
            request.Description,
            request.Price,
            request.DiscountId,
            request.CategoryId,
            request.ManufacturerId,
            request.InventoryId);
        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}