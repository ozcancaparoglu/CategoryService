using CategoryService.Domain.CategoryAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CategoryService.Application.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> ChildCategories(int mainId, ICollection<Category> allCategories);
    }
}