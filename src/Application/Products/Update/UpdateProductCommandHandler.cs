using Domain.Products;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId)
            ?? throw new ProductNotFoundException(request.ProductId);

        product.Update(request.Name, request.Price, request.Stock);
        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}