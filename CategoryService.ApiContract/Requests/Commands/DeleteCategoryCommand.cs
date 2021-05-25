using MediatR;

namespace CategoryService.ApiContract.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<Result<object>>
    {
        public int Id { get; set; }
    }
}
