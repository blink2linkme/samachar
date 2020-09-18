using System.Collections.Generic;

namespace Samachar.Domain.ViewModels
{
    /// <summary>
    /// Represents a view model for Tags
    /// </summary>
    public class TagsViewModel
    {
        public int TotalRows { get; set; }
        public int Rows { get; set; }
        public int Page { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
