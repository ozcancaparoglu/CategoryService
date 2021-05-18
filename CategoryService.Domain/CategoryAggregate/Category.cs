using CategoryService.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CategoryService.Domain.CategoryAggregate
{
    public class Category : DomainBase
    {
        public int? ParentId { get; private set; }

        [Required]
        [StringLength(250)]
        public string Name { get; private set; }

        public string DisplayName { get; private set; }

        public string Description { get; private set; }

        private readonly List<CategoryAttribute> _categoryAttributes;
        public IReadOnlyCollection<CategoryAttribute> CategoryAttributes => _categoryAttributes;

        protected Category()
        {
            _categoryAttributes = new List<CategoryAttribute>();
        }

        public Category(int? parentId, string name, string displayName, string description) : this()
        {
            ParentId = parentId;
            Name = name;
            DisplayName = displayName;
            Description = description;
        }

        public void SetCategory(int? parentId, string name, string displayName, string description)
        {
            ParentId = parentId;
            Name = name;
            DisplayName = displayName;
            Description = description;
        }

        public CategoryAttribute VerifyOrAddCategoryAttribute(int attributeId, bool isRequired, bool isVariantable)
        {
            var existing = _categoryAttributes.SingleOrDefault(x => x.AttributeId == attributeId);

            if (existing != null)
                return existing;

            var newEntry = new CategoryAttribute(Id, attributeId, isRequired, isVariantable);

            _categoryAttributes.Add(newEntry);

            return newEntry;
        }
    }
}
