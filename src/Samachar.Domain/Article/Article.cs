using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Article
    /// </summary>
    public class Article : BaseEntity
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ArticleTypes ArticleTypes { get; set; }
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public DateTime? PublishOn { get; set; }
        public string BaseImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public int ArticleStatusId { get; set; }
        public string Culture { get; set; }
        public virtual ArticleContent ArticleContent { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ArticleTags> ArticleTags { get; set; }
        public virtual ICollection<ArticleStatus> ArticleStatus { get; set; }
    }
}