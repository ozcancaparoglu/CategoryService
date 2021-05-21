using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Queries;
using CategoryService.Application.AutoMapper;
using CategoryService.Application.Services;
using CategoryService.Domain;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICategoryService categoryService;

        private readonly IGenericRepository<Category> categoryRepo;

        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.categoryService = categoryService;

            categoryRepo = this.unitOfWork.Repository<Category>();
        }


        public async Task<Result<List<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var allCategoryList = await categoryRepo.GetAll(); //TODO: Cache
            var mainCategories = allCategoryList.Where(x => x.ParentId == null);

            foreach (var mainCategory in mainCategories)
            {
                mainCategory.SubCategories.AddRange(await categoryService.ChildCategories(mainCategory.Id, allCategoryList));
            }

            return await Result<List<CategoryResponse>>.SuccessAsync(autoMapper.MapCollection<Category, CategoryResponse>(mainCategories));
        }
    }
}
