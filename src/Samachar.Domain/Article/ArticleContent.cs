using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Content
    /// </summary>
    public class ArticleContent : BaseEntity
    {
        public int Id { get; set; }
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [DisplayName("Content")]
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Lenght Not Valid!", MinimumLength = 10)]
        public string Content { get; set; }
        public virtual Article Article { get; set; }
    }
}