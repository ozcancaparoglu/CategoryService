using System.Collections.Generic;

namespace CategoryService.ApiContract.Contracts
{
    public class CategoryWithAttributesResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public List<CategoryAttributeResponse> CategoryAttributes { get; set; }
    }
}
