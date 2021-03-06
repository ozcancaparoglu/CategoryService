namespace CategoryService.ApiContract.Contracts
{
    public class CategoryCreateUpdateResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
