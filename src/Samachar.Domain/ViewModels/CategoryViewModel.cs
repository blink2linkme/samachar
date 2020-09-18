using System.Collections.Generic;

namespace Samachar.Domain.ViewModels
{
    /// <summary>
    /// Represents a view model for Category
    /// </summary>
    public class CategoryViewModel
    {
        public int TotalRows { get; set; }
        public int Rows { get; set; }
        public int Page { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
