using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Article
    /// </summary>
    public class Article : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        //[Required]
        //public ArticleTypes ArticleTypes { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public DateTime? PublishOn { get; set; }
        public bool IsPublished { get; set; }
        public int ArticleStatusId { get; set; }
        //public virtual ArticleContent ArticleContent { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }
        //public virtual ICollection<ArticleStatus> ArticleStatus { get; set; }
    }
}