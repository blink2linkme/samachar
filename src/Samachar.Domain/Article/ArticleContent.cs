using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Content
    /// </summary>
    public class ArticleContent : BaseEntity
    {
        public int Id { get; set; }
        [DisplayName("Short Description")]
        [Required]
        public string ShortDescription { get; set; }
        [DisplayName("Content")]
        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Lenght Not Valid!", MinimumLength = 10)]
        public string Content { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}