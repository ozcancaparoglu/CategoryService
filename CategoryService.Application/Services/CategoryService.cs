using CategoryService.Application.CacheServices;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICacheService cacheService;

        private List<Category> _allCategories;
        public List<Category> AllCategories 
        { 
            get { return _allCategories; } 
            set { _allCategories = value; } 
        }


        public CategoryService(IUnitOfWork unitOfWork, ICacheService cacheService)
        {
            this.unitOfWork = unitOfWork;
            this.cacheService = cacheService;

            _allCategories = new List<Category>();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            if (!cacheService.TryGetValue(CacheConstants.CategoryCacheKey, out _allCategories))
            {
                AllCategories = (List<Category>)await unitOfWork.Repository<Category>().GetAll();
                cacheService.Add(CacheConstants.CategoryCacheKey, AllCategories, CacheConstants.CategoryCacheTime);
            }

            return AllCategories;
        }

        public async Task<List<Category>> ChildCategories(int mainId)
        {
            await GetAllCategories();

            var subCategories = AllCategories.Where(x => x.ParentId == mainId);

            foreach (var subCategory in subCategories)
            {
                subCategory.SubCategories.AddRange(await ChildCategories(subCategory.Id));
            }

            return subCategories.ToList();
        }

        public async Task<bool> CheckIfCategoryLeaf(int categoryId)
        {
            await GetAllCategories();

            return AllCategories.Any(x => x.ParentId == categoryId) == false;
        }
    }
}
