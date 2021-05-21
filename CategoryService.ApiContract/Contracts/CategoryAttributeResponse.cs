namespace CategoryService.ApiContract.Contracts
{
    public class CategoryAttributeResponse
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVariantable { get; set; }
    }
}