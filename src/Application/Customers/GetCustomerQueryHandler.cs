using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers;

public record GetCustomerQuery(int CustomerId) : IRequest<CustomerResponse>;

public record CustomerResponse(
    int CustomerId,
    string Email,
    string Phone,
    string Name,
    string LastName);


internal sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly MerchantiseDBContext _context;

    public GetCustomerQueryHandler(MerchantiseDBContext context)
    {
        _context = context;
    }

    public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .Where(p => p.CustomerId == request.CustomerId)
            .Select(p => new CustomerResponse(
                p.CustomerId,
                p.Email,
                p.Phone,
                p.Name,
                p.LastName))
            .FirstOrDefaultAsync(cancellationToken);

        if (customer is null)
        {
            throw new NotFoundException(request.CustomerId, nameof(Customer));
        }
        return customer;
    }
}