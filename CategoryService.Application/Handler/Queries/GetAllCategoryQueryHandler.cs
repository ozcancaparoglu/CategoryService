using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Queries;
using CategoryService.Application.AutoMapper;
using CategoryService.Application.Services;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Queries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, Result<List<CategoryResponse>>>
    {
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICategoryService categoryService;

        public GetAllCategoryQueryHandler(IAutoMapperConfiguration autoMapper, ICategoryService categoryService)
        {
            this.autoMapper = autoMapper;
            this.categoryService = categoryService;
        }

        public async Task<Result<List<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await categoryService.GetAllCategories();
            var mainCategories = allCategories.Where(x => x.ParentId == null);

            foreach (var mainCategory in mainCategories)
            {
                mainCategory.SubCategories.AddRange(await categoryService.ChildCategories(mainCategory.Id));
            }

            return await Result<List<CategoryResponse>>.SuccessAsync(autoMapper.MapCollection<Category, CategoryResponse>(mainCategories));
        }
    }
}
