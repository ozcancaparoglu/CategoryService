using CategoryService.ApiContract.Contracts;
using MediatR;

namespace CategoryService.ApiContract.Requests.Queries
{
    public class GetByIdCategoryQuery : IRequest<Result<CategoryGetByIdResponse>>
    {
        public int Id { get; set; }
    }
}
