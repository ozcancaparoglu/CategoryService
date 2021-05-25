using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.Application.Services;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<object>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryService categoryService; 

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.categoryService = categoryService;
        }
        

        public async Task<Result<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!await categoryService.CheckIfCategoryLeaf(request.Id))
                return await Result<object>.FailureAsync("Category is not leaf so cannot be deleted."); //TODO : Exception messages standartization.

            var entity = await unitOfWork.Repository<Category>().GetById(request.Id);

            if (entity == null)
                return await Result<object>.FailureAsync("InvalidId"); //TODO : Exception messages standartization

            #region CategoryAttributes

            var relatedEntities = await unitOfWork.Repository<CategoryAttribute>().Filter(x => x.CategoryId == request.Id);

            await unitOfWork.Repository<CategoryAttribute>().BulkDelete(relatedEntities.ToList());

            #endregion

            entity.Delete();

            unitOfWork.Repository<Category>().Update(entity);

            await unitOfWork.CommitAsync();

            return await Result<object>.SuccessAsync($"{entity.Name} is deleted with relations successfully."); //TODO : Exception messages standartization
        }
    }
}
