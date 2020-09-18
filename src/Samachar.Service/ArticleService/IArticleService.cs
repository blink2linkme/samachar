using Samachar.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service for article
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Asynchronous method to get the collection of Article
        /// </summary>
        /// <returns>Collection of Article</returns>
        Task<ICollection<Article>> GetAsync(int page, int rows);

        /// <summary>
        /// Asynchronous method to add or update the Article
        /// </summary>
        /// <param name="article">Article object</param>
        /// <returns>Status</returns>
        Task<int> AddOrUpdateAsync(Article article);

        /// <summary>
        /// Asynchronous method to get an article by identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>Article</returns>
        Task<Article> GetbyIdentifierAsync(int identifier);

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
