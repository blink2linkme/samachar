using System.Collections.Generic;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an Image Type Entity
    /// </summary>
    public class ImageType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}