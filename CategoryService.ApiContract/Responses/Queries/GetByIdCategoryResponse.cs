using System;

namespace CategoryService.ApiContract.Responses.Queries
{
    public class GetByIdCategoryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int State { get; set; }
    }
}
