using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Customers;

public record UpdateCustomerCommand(
    int CustomerId,
    string Email,
    string Phone,
    string Name,
    string LastName) : IRequest;

public record UpdateCustomerRequest(
    string Email,
    string Phone,
    string Name,
    string LastName);

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IBaseRepository<Customer> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IBaseRepository<Customer> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId)
            ?? throw new NotFoundException(request.CustomerId, nameof(Customer));
        
        customer.Update(
            request.Email,
            request.Phone,
            request.Name,
            request.LastName);
        _repository.Update(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}