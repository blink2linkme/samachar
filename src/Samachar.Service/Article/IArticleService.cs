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
        Task<ICollection<Article>> GetAsync();

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
        /// <returns></returns>
        Task<Article> GetbyIdentifierAsync(int identifier);
    }
}
