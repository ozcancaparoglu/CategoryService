using CategoryService.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        private List<Category> _subCategories;
        [NotMapped]
        public List<Category> SubCategories => _subCategories;

        protected Category()
        {
            _categoryAttributes = new List<CategoryAttribute>();
            _subCategories = new List<Category>();
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

        public void SetSubCategories(List<Category> subCategories) => _subCategories = subCategories;

        public void VerifyOrAddCategoryAttribute(int attributeId, bool isRequired, bool isVariantable)
        {
            if (!_categoryAttributes.Any(x => x.AttributeId == attributeId))
            {
                var newEntry = new CategoryAttribute(Id, attributeId, isRequired, isVariantable);

                _categoryAttributes.Add(newEntry);
            }

        }
    }
}
