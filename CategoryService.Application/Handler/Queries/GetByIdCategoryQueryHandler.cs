using CategoryService.ApiContract;
using CategoryService.ApiContract.Requests.Queries;
using CategoryService.ApiContract.Responses.Queries;
using CategoryService.Application.Assembler;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Queries
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, Result<GetByIdCategoryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoryRepo;
        private readonly ICategoryAssembler categoryAssembler;


        public GetByIdCategoryQueryHandler(IUnitOfWork unitOfWork, ICategoryAssembler categoryAssembler)
        {
            this.unitOfWork = unitOfWork;
            categoryRepo = this.unitOfWork.Repository<Category>();
            this.categoryAssembler = categoryAssembler;
        }

        public async Task<Result<GetByIdCategoryResponse>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await categoryRepo.GetById(request.Id);

            if (entity == null)
                return await Result<GetByIdCategoryResponse>.FailureAsync("Invalid id");

            return await categoryAssembler.MapToGetByIdCategoryResponse(entity);
        }
    }
}
