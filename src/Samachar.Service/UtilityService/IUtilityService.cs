using Samachar.Domain;
using System.Collections.Generic;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a utility service
    /// </summary>
    public interface IUtilityService
    {
        /// <summary>
        /// List of Article Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArticleTypes> ArticleTypes();
    }
}
