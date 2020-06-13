using Samachar.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service for article
    /// </summary>
    public class ArticleService : IArticleService
    {
        public ArticleService()
        {

        }

        public Task<int> AddOrUpdateAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetbyIdentifierAsync(int identifier)
        {
            throw new NotImplementedException();
        }
    }
}
