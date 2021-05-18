using System;

namespace CategoryService.ApiContract.Responses.Commands
{
    public class UpdateCategoryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
