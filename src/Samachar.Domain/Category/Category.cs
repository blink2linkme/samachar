using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Category
    /// </summary>
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public int Sequence { get; set; }
        public int ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}