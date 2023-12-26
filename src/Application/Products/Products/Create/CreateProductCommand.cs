using MediatR;

namespace Application.Products.Products.Create;

public record CreateProductCommand (
               string productName,
               string description,
               decimal price,
               int discountId,
               int categoryId,
               int? manufacturerId,
               int? inventoryId) : IRequest;