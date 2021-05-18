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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<UpdateCategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoryRepo;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categoryRepo = this.unitOfWork.Repository<Category>();
        }

        public async Task<Result<UpdateCategoryResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await categoryRepo.GetById(request.Id);

            if (entity == null)
                return await Result<UpdateCategoryResponse>.FailureAsync("InvalidId"); //TODO : Exception messages standartization
                
            entity.SetCategory(request.ParentId, request.Name, request.DisplayName, request.Description);

            categoryRepo.Update(entity);

            await unitOfWork.CommitAsync();

            var dto = new UpdateCategoryResponse
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                UpdatedDate = entity.UpdatedDate.Value
            };

            return await Result<UpdateCategoryResponse>.SuccessAsync(dto);
        }
    }
}
