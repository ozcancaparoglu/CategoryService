using CategoryService.Domain.CategoryAggregate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<List<Category>> ChildCategories(int mainId, ICollection<Category> allCategories)
        {
            var subCategories = allCategories.Where(x => x.ParentId == mainId);

            foreach (var subCategory in subCategories)
            {
                subCategory.SubCategories.AddRange(await ChildCategories(subCategory.Id, allCategories));
            }

            return subCategories.ToList();
        }
    }
}
