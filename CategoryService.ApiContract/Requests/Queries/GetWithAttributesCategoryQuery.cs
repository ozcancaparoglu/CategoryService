using CategoryService.ApiContract.Contracts;
using MediatR;

namespace CategoryService.ApiContract.Requests.Queries
{
    public class GetWithAttributesCategoryQuery : IRequest<Result<CategoryWithAttributesResponse>>
    {
        public int Id { get; set; }
    }
}
