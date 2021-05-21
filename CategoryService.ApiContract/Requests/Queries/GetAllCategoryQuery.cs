using CategoryService.ApiContract.Contracts;
using MediatR;
using System.Collections.Generic;

namespace CategoryService.ApiContract.Requests.Queries
{
    public class GetAllCategoryQuery : IRequest<Result<List<CategoryResponse>>>
    {
    }
}
