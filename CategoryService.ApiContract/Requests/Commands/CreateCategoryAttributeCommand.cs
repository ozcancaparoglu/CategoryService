using MediatR;
using System.Collections.Generic;

namespace CategoryService.ApiContract.Requests.Commands
{
    public class CreateCategoryAttributeCommand : IRequest<Result<object>>
    {
        public int CategoryId { get; set; }
        public List<CreateCategoryAttribute> CreateCategoryAttributeList { get; set; }
    }

    public class CreateCategoryAttribute
    {
        public int AttributeId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVariantable { get; set; }
    }
}
