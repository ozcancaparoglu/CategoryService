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
    public class GetWithAttributesQueryHandler : IRequestHandler<GetWithAttributesCategoryQuery, Result<CategoryWithAttributesResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;

        public GetWithAttributesQueryHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }


        public async Task<Result<CategoryWithAttributesResponse>> Handle(GetWithAttributesCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.Repository<Category>().FindByProperties(x => x.Id == request.Id, "CategoryAttributes");

            if (entity == null)
                return await Result<CategoryWithAttributesResponse>.FailureAsync("Invalid Id.");

            return await Result<CategoryWithAttributesResponse>.SuccessAsync(autoMapper.MapObject<Category, CategoryWithAttributesResponse>(entity));
        }
    }
}
