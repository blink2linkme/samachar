using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samachar.Domain
{
    /// <summary>
    /// Represents an entity for Image
    /// </summary>
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public int ImageTypeId { get; set; }
        public virtual ImageType ImageType { get; set; }
    }
}