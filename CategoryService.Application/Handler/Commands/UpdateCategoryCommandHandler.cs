﻿using CategoryService.ApiContract;
using CategoryService.ApiContract.Contracts;
using CategoryService.ApiContract.Requests.Commands;
using CategoryService.Application.AutoMapper;
using CategoryService.Domain;
using CategoryService.Domain.CategoryAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CategoryService.Application.Handler.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<CategoryCreateUpdateResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;

        private readonly IGenericRepository<Category> categoryRepo;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;

            categoryRepo = this.unitOfWork.Repository<Category>();
        }

        public async Task<Result<CategoryCreateUpdateResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await categoryRepo.GetById(request.Id);

            if (entity == null)
                return await Result<CategoryCreateUpdateResponse>.FailureAsync("InvalidId"); //TODO : Exception messages standartization
                
            entity.SetCategory(request.ParentId, request.Name, request.DisplayName, request.Description);

            categoryRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return await Result<CategoryCreateUpdateResponse>.SuccessAsync(autoMapper.MapObject<Category, CategoryCreateUpdateResponse>(entity));
        }
    }
}
