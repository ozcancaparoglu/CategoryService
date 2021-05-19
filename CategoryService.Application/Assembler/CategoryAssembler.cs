using CategoryService.ApiContract;
using CategoryService.ApiContract.Responses.Commands;
using CategoryService.ApiContract.Responses.Queries;
using CategoryService.Domain.CategoryAggregate;
using System.Threading.Tasks;

namespace CategoryService.Application.Assembler
{
    public class CategoryAssembler : ICategoryAssembler
    {
        public async Task<Result<CreateCategoryResponse>> MapToCreateCategoryResponse(Category entity)
        {
            return await Result<CreateCategoryResponse>.SuccessAsync(
                new CreateCategoryResponse
                {
                    Id = entity.Id,
                    ParentId = entity.ParentId,
                    Name = entity.Name,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    CreatedDate = entity.CreatedDate
                });
        }


        public async Task<Result<GetByIdCategoryResponse>> MapToGetByIdCategoryResponse(Category entity)
        {
            return await Result<GetByIdCategoryResponse>.SuccessAsync(
                new GetByIdCategoryResponse
                {
                    Id = entity.Id,
                    ParentId = entity.ParentId,
                    Name = entity.Name,
                    DisplayName = entity.DisplayName,
                    Description = entity.Description,
                    CreatedDate = entity.CreatedDate,
                    UpdatedDate = entity.UpdatedDate,
                    State = (int)entity.State
                });
        }
    }
}
