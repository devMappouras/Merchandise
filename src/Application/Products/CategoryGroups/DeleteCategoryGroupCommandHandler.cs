using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.CategoryGroups;

public record DeleteCategoryGroupCommand(int GroupId) : IRequest;

internal sealed class DeleteCategoryGroupCommandHandler : IRequestHandler<DeleteCategoryGroupCommand>
{
    private readonly IBaseRepository<CategoryGroup> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryGroupCommandHandler(IBaseRepository<CategoryGroup> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryGroupCommand request, CancellationToken cancellationToken)
    {
        var categoryGroup = await _repository.GetByIdAsync(request.GroupId);
        if (categoryGroup is null)
            throw new NotFoundException(request.GroupId, nameof(CategoryGroup));

        _repository.Delete(categoryGroup);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
