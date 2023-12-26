using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.CategoryGroups;

public record UpdateCategoryGroupCommand(
    int GroupId,
    string GroupName) : IRequest;

public record UpdateCategoryGroupRequest(
    string GroupName);

internal sealed class UpdateCategoryGroupCommandHandler : IRequestHandler<UpdateCategoryGroupCommand>
{
    private readonly IBaseRepository<CategoryGroup> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryGroupCommandHandler(IBaseRepository<CategoryGroup> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryGroupCommand request, CancellationToken cancellationToken)
    {
        var categoryGroup = await _repository.GetByIdAsync(request.GroupId)
            ?? throw new NotFoundException(request.GroupId, nameof(CategoryGroup));

        categoryGroup.Update(              
            request.GroupId,
            request.GroupName);
        _repository.Update(categoryGroup);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}