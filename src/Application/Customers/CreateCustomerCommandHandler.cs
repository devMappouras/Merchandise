using Domain.Entities;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Customers;

public record CreateCustomerCommand(
    string Email,
    string Password,
    string Phone,
    string Name,
    string LastName) : IRequest;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IBaseRepository<Customer> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCustomerCommandHandler(IBaseRepository<Customer> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var mapper = new MapperlyMapper();

        var customer = mapper.Map(request);
        _repository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
