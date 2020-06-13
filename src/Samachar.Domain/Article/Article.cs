using System;
using System.Collections.Generic;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Article
    /// </summary>
    public class Article : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ArticleTypes ArticleTypes { get; set; }
        public int CategoryId { get; set; }
        public string Slug { get; set; }
        public DateTime? PublishOn { get; set; }
        public bool IsPublished { get; set; }
        public int ArticleStatusId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<ArticleStatus> ArticleStatus { get; set; }
    }
}