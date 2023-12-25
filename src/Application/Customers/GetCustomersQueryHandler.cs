using Domain.Entities;
using MediatR;

namespace Application.Customers;

public record GetCustomersQuery() : IRequest<IEnumerable<CustomerResponse>?>;

internal sealed class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerResponse>?>
{
    private readonly IBaseRepository<Customer> _repository;

    public GetCustomersQueryHandler(IBaseRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerResponse>?> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        // Mapper usage
        var mapper = new MapperlyMapper();

        var customers = await _repository.GetAllAsync();
        return mapper.Map(customers);
    }
}