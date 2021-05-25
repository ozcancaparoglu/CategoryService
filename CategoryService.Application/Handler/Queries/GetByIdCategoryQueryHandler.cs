using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Queries;
using CategoryService.Application.AutoMapper;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Queries
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, Result<CategoryGetByIdResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        public GetByIdCategoryQueryHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public async Task<Result<CategoryGetByIdResponse>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.Repository<Category>().GetById(request.Id);

            if (entity == null)
                return await Result<CategoryGetByIdResponse>.FailureAsync("Invalid id");

            return await Result<CategoryGetByIdResponse>.SuccessAsync(autoMapper.MapObject<Category, CategoryGetByIdResponse>(entity));
        }
    }
}
