using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.Application.AutoMapper;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryCreateUpdateResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public async Task<Result<CategoryCreateUpdateResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category(request.ParentId, request.Name, request.DisplayName, request.Description);

            await unitOfWork.Repository<Category>().Add(entity);

            await unitOfWork.CommitAsync();

            return await Result<CategoryCreateUpdateResponse>.SuccessAsync(autoMapper.MapObject<Category, CategoryCreateUpdateResponse>(entity));
        }
    }
}
