using Samachar.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service for article tags
    /// </summary>
    public interface IArticleTagsService
    {
        /// <summary>
        /// Get the Articles Tags from Data Source by Article Id
        /// </summary>
        /// <param name="articleId">Article Identifier</param>
        /// <returns>Collection of Article Tags</returns>
        Task<ICollection<ArticleTags>> GetArticlesTagsAsync(int articleId);
    }
}
