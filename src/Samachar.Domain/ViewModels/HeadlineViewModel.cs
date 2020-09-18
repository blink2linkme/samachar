using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samachar.Domain.ViewModels
{
    /// <summary>
    /// Represents a view model for headline
    /// </summary>
    public class HeadlineViewModel
    {
        public ICollection<Article> Popular { get; set; }
        public ICollection<Article> Latest { get; set; }
    }
}
