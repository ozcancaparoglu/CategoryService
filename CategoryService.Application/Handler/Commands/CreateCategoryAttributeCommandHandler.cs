using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.Application.AutoMapper;
using CategoryService.Application.Services;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Commands
{
    public class CreateCategoryAttributeCommandHandler : IRequestHandler<CreateCategoryAttributeCommand, Result<object>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICategoryService categoryService;
        public CreateCategoryAttributeCommandHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.categoryService = categoryService;
        }

        public async Task<Result<object>> Handle(CreateCategoryAttributeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await unitOfWork.Repository<Category>().FindByProperties(x => x.Id == request.CategoryId, "CategoryAttributes");

                if(entity == null)
                    return await Result<object>.FailureAsync("InvalidId"); //TODO : Exception messages standartization

                if (!await categoryService.CheckIfCategoryLeaf(request.CategoryId))
                    return await Result<object>.FailureAsync("Category is not leaf so attributes cannot be added."); //TODO : Exception messages standartization

                foreach (var attribute in request.CreateCategoryAttributeList)
                {
                    entity.VerifyOrAddCategoryAttribute(attribute.AttributeId, attribute.IsRequired, attribute.IsVariantable);
                    
                    unitOfWork.Repository<Category>().Update(entity);
                }

                await unitOfWork.CommitAsync();

                return await Result<object>.SuccessAsync("Data inserted successfully."); //TODO : Exception messages standartization

            }
            catch (Exception ex)
            {
                return await Result<object>.FailureAsync(ex.Message);
            }
        }
    }
}
