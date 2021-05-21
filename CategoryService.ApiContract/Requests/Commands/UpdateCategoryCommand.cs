using CategoryService.ApiContract.Contracts;
using MediatR;

namespace CategoryService.ApiContract.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<Result<CategoryCreateUpdateResponse>>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
