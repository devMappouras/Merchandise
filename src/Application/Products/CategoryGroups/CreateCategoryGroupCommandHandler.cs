using Domain.Entities;
using Infrastructure.DataAccess;
using MediatR;

namespace Application.Products.CategoryGroups;

public record CreateCategoryGroupCommand(
               string GroupName) : IRequest;

public class CreateCategoryGroupCommandHandler : IRequestHandler<CreateCategoryGroupCommand>
{
    private readonly IBaseRepository<CategoryGroup> _repository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryGroupCommandHandler(IBaseRepository<CategoryGroup> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryGroupCommand request, CancellationToken cancellationToken)
    {
        var mapper = new MapperlyMapper();

        var categoryGroup = mapper.Map(request);
        _repository.Add(categoryGroup);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
