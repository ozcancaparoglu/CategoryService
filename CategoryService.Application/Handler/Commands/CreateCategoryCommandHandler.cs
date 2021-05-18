using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.ApiContract.Responses.Commands;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoryRepo;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categoryRepo = this.unitOfWork.Repository<Category>();
        }

        public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category(request.ParentId, request.Name, request.DisplayName, request.Description);

            await categoryRepo.Add(entity);

            await unitOfWork.CommitAsync();

            var dto = new CreateCategoryResponse
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate
            };

            return await Result<CreateCategoryResponse>.SuccessAsync(dto);
        }
    }
}
