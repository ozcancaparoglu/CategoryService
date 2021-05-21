using AutoMapper;
using CategoryService.ApiContract.Contracts;
using CategoryService.Domain.CategoryAggregate;

namespace CategoryService.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        private readonly int depth = 5;

        public MapperProfile()
        {
            CreateMap<Category, CategoryResponse>().MaxDepth(depth).ReverseMap();
            CreateMap<Category, CategoryCreateUpdateResponse>().MaxDepth(depth).ReverseMap();
            CreateMap<Category, CategoryGetByIdResponse>().MaxDepth(depth).ReverseMap();
            CreateMap<Category, CategoryWithAttributesResponse>().MaxDepth(depth).ReverseMap();



            CreateMap<CategoryAttribute, CategoryAttributeResponse>().MaxDepth(depth).ReverseMap();
        }

    }
}
