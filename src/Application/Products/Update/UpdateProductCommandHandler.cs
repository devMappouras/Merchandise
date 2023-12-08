using Domain.Products;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.Update;

public record UpdateProductCommand(
    int ProductId,
    string Name,
    decimal Price,
    int Stock) : IRequest;

public record UpdaterProductRequest(
    int ProductId,
    string Name,
    decimal Price,
    int Stock);

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

        //product.Update(request.Name, request.Price, request.Stock);
        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}