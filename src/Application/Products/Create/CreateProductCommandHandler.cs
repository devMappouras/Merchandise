﻿using Domain.Products;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price, request.Stock);
        _productRepository.Add(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
