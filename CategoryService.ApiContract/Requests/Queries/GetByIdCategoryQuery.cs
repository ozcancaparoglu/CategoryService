using CategoryService.ApiContract.Responses.Queries;
using MediatR;

namespace CategoryService.ApiContract.Requests.Queries
{
    public class GetByIdCategoryQuery : IRequest<Result<GetByIdCategoryResponse>>
    {
        public int Id { get; set; }
    }
}
