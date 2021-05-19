using CategoryService.ApiContract;
using CategoryService.ApiContract.Responses.Commands;
using CategoryService.ApiContract.Responses.Queries;
using CategoryService.Domain.CategoryAggregate;
using System.Threading.Tasks;

namespace CategoryService.Application.Assembler
{
    public interface ICategoryAssembler
    {
        Task<Result<CreateCategoryResponse>> MapToCreateCategoryResponse(Category entity);
        Task<Result<GetByIdCategoryResponse>> MapToGetByIdCategoryResponse(Category entity);
    }
}