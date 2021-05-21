using System.Collections.Generic;

namespace CategoryService.ApiContract.Contracts
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public List<CategoryResponse> SubCategories { get; set; }
    }
}
