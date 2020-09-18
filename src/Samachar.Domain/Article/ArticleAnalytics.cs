using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an Article Analytics Data
    /// </summary>
    public class ArticleAnalytics
    {
        public int ViewsCount { get; set; }
        public int Shares { get; set; }
        public virtual List<SocialMediaAnalytics> SocialMediaAnalytics { get; set; }
    }

    public class SocialMediaAnalytics
    {
        public SocialMedias SocialMedias { get; set; }
        public int ViewsCount { get; set; }
        public int Share { get; set; }
    }

    public class SocialMedias : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoUrl { get; set; }
        [NotMapped]
        public IFormFile Logo { get; set; }
    }
}
