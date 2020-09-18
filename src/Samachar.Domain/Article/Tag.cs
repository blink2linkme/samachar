using System.Collections.Generic;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Tag
    /// </summary>
    public class Tag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
