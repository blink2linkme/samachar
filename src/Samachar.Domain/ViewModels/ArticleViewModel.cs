using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samachar.Domain.ViewModels
{
    /// <summary>
    /// Represents a view model for article
    /// </summary>
    public class ArticleViewModel : Article
    {
        [NotMapped]
        public IFormFile BaseImage { get; set; }
        public int[] SelectedTags { get; set; }
        public IEnumerable<SelectListItem> Tags { get; set; }
    }
}
