using Samachar.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Repository
{
    /// <summary>
    /// Represents a Repository for Article
    /// </summary>
    public interface IArticleRepository
    {
        /// <summary>
        /// Get the Articles from Data source
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="rows">Numbers of Rows</param>
        /// <returns>Collection of Article</returns>
        Task<ICollection<Article>> GetArticlesAsync(int page, int rows);

        /// <summary>
        /// Add or Update the Article
        /// </summary>
        /// <param name="article">Article object</param>
        /// <returns>Status of the process</returns>
        Task<int> AddOrUpdate(Article article);

        /// <summary>
        /// Returns a Article
        /// </summary>
        /// <param name="id">Article Identifier</param>
        /// <returns>Article Object</returns>
        Task<Article> GetArticleAsync(int id);

        /// <summary>
        /// Asynchoronous method to get popular article
        /// </summary>
        /// <returns>Collection of article</returns>
        Task<ICollection<Article>> GetPopularArticleAsync();

        /// <summary>
        /// Asynchoronous method to get latest article
        /// </summary>
        /// <returns>Collection of Article</returns>
        Task<ICollection<Article>> GetLatestAsync();
    }
}
