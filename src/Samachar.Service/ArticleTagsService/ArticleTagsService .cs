using Microsoft.Extensions.Logging;
using Samachar.Domain;
using Samachar.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samachar.Service
{
    /// <summary>
    /// Represents a service for article
    /// </summary>
    public class ArticleTagsService : IArticleTagsService
    {
        private readonly IArticleTagsRepository _articleTagsRepository;
        private readonly ILogger<ArticleTagsService> _logger;
        public ArticleTagsService(IArticleTagsRepository articleTagsRepository, ILogger<ArticleTagsService> logger)
        {
            _articleTagsRepository = articleTagsRepository;
            _logger = logger;
        }

        public async Task<ICollection<ArticleTags>> GetArticlesTagsAsync(int articleId)
        {
            return await _articleTagsRepository.GetArticlesTagsAsync(articleId);
        }
    }
}
