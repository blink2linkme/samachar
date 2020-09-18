using Samachar.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    /// <summary>
    /// Represents a Repository for Article
    /// </summary>
    public interface IArticleTagsRepository
    {
        /// <summary>
        /// Get the Articles Tags from Data source
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="rows">Numbers of Rows</param>
        /// <returns>Collection of ArticleTags</returns>
        Task<ICollection<ArticleTags>> GetArticlesAsync(int page, int rows);

        /// <summary>
        /// Get the Articles Tags from Data Source by Article Id
        /// </summary>
        /// <param name="articleId">Article Identifier</param>
        /// <returns>Collection of Article Tags</returns>
        Task<ICollection<ArticleTags>> GetArticlesTagsAsync(int articleId);

        /// <summary>
        /// Add or Update the Article Tags
        /// </summary>
        /// <param name="articleTags">ArticleTags object</param>
        /// <returns>Status of the process</returns>
        Task<int> AddOrUpdate(ICollection<ArticleTags> articleTags);

        /// <summary>
        /// Returns a ArticleTags
        /// </summary>
        /// <param name="id">ArticleTags Identifier</param>
        /// <returns>Article Object</returns>
        Task<ArticleTags> GetArticleAsync(int id);
    }
}
