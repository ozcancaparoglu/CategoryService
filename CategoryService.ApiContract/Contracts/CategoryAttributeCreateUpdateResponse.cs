namespace CategoryService.ApiContract.Contracts
{
    public class CategoryAttributeCreateUpdateResponse
    {
        public bool Success { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVariantable { get; set; }
    }
}


