using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Customers;

public record DeleteCustomerCommand(int CustomerId) : IRequest;

internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IBaseRepository<Customer> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IBaseRepository<Customer> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.CustomerId);
        if (customer is null)
            throw new NotFoundException(request.CustomerId, nameof(Customer));

        _repository.Delete(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
