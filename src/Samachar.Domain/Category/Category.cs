using System.Collections.Generic;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Category
    /// </summary>
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}