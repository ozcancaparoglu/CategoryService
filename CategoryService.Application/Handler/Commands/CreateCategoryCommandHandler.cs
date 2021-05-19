using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.ApiContract.Responses.Commands;
using CategoryService.Application.Assembler;
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
        private readonly ICategoryAssembler categoryAssembler;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryAssembler categoryAssembler)
        {
            this.unitOfWork = unitOfWork;
            categoryRepo = this.unitOfWork.Repository<Category>();
            this.categoryAssembler = categoryAssembler;
        }

        public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category(request.ParentId, request.Name, request.DisplayName, request.Description);

            await categoryRepo.Add(entity);

            await unitOfWork.CommitAsync();

            return await categoryAssembler.MapToCreateCategoryResponse(entity);
        }
    }
}
