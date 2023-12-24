using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.productName,
            request.description,
            request.price,
            request.discountId,
            request.categoryId,
            request.manufacturerId,
            request.inventoryId);
        
        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
