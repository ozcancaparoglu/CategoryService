using CategoryService.ApiContract.Responses.Commands;
using MediatR;

namespace CategoryService.ApiContract.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<Result<CreateCategoryResponse>>
    {
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
